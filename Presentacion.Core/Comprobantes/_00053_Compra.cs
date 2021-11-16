using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using IServicio.ListaPrecio;
using IServicios.Articulo.DTOs;
using IServicios.Compras;
using IServicios.Compras.DTOs;
using IServicios.Comprobante;
using IServicios.Proveedores.DTOs;
using Presentacion.Core.Comprobantes.Clases;
using Presentacion.Core.Proveedor;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00053_Compra : FormBase
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly ICompraServicio _compraServicio;

        private ProveedoresDto _proveedorSeleccionado;
        private ConfiguracionDto _configuracionDto;
        private ArticuloCompraDto _articuloSeleccionado;
        private CompraView _detalleCompra;
        private ItemCompraView _itemSeleccionado;

        public _00053_Compra(ICompraServicio compraServicio, IConfiguracionServicio configuracionServicio, IArticuloServicio articuloServicio)
        {
            InitializeComponent();

            _articuloServicio = articuloServicio;
            _compraServicio = compraServicio;
            _configuracionServicio = configuracionServicio;

            _configuracionDto = _configuracionServicio.Obtener();

            _detalleCompra = new CompraView();

            if (_configuracionDto == null)
            {
                MessageBox.Show("Carge la configuracion del Sistema");
                Close();
            }

            txtCodigo.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoLetras(sender, args);
            };

            lblFechaActual.Text = DateTime.Today.ToShortDateString();
        }

        private void _00053_Compra_Load(object sender, EventArgs e)
        {
            CargarDatosCuerpo();
            CargarPie();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    _articuloSeleccionado = _articuloServicio.ObtenerArticuloPorCodigo(txtCodigo.Text);

                    if (_articuloSeleccionado != null)
                    {
                        txtCodigo.Text = _articuloSeleccionado.CodigoBarra;
                        txtDescripcion.Text = _articuloSeleccionado.Descripcion;
                        txtPrecioUnitario.Text = _articuloSeleccionado.PrecioStr;
                        txtSubTotalLinea.Text = (_articuloSeleccionado.Precio * nudCantidad.Value).ToString();
                        nudCantidad.Focus();
                        nudCantidad.Select(0, nudCantidad.Text.Length);
                        return;
                    }
                    else
                    {
                        LimpiarParaNuevoItem();
                    }
                }
            }

            e.Handled = false;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _itemSeleccionado = (ItemCompraView)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

            }
            else
            {
                MessageBox.Show("No hay articulos Cargados");
                _itemSeleccionado = null;
            }
        }

        private void _00053_Compra_Leave(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count > 0)
            {
                if (MessageBox.Show("Ha cargado elementos. Desea Eliminarlos?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _detalleCompra = new CompraView();

                    CargarDatosCuerpo();
                    CargarPie();
                    LimpiarParaNuevoItem();
                }
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            AgregarItem(_articuloSeleccionado, nudCantidad.Value);

            LimpiarParaNuevoItem();
            CargarDatosCuerpo();
            CargarPie();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            var compraDto = new CompraDto();

            compraDto.SubTotal = 0;
            compraDto.Total = 0;

            foreach (var item in _detalleCompra.Items)
            {
                compraDto.Items.Add(new DetalleCompraDto
                {
                    Cantidad = item.Cantidad,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    ArticuloId = item.ArticuloId,
                    Codigo = item.CodigoBarra,
                    SubTotal = item.SubTotal,
                });
            }

            _compraServicio.IncrementarStock(compraDto);
            if (MessageBox.Show("Desea terminar la compra?", "Atencion",  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
                LimpiarNuevaCompra();
            }

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            txtSubTotalLinea.Text = (_articuloSeleccionado.Precio * nudCantidad.Value).ToString();
        }

        //=================================================== Metodos Privados =================================================== // 

        private void btnBuscarCliente_Click(object sender, System.EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ProveedoresLookUp>();
            fLookUpCliente.ShowDialog();

            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                _proveedorSeleccionado = (ProveedoresDto)fLookUpCliente.EntidadSeleccionada;
                txtCUIT.Text = _proveedorSeleccionado.CUIL;
                txtRazonSocial.Text = _proveedorSeleccionado.RazonSocial;
                txtDomicilio.Text = _proveedorSeleccionado.Direccion;
                txtTelefono.Text = _proveedorSeleccionado.Telefono;
                txtCondicionIva.Text = _proveedorSeleccionado.CondicionIva;               
            }
        }

        private void CargarDatosCuerpo()
        {
            dgvGrilla.DataSource = _detalleCompra.Items.ToList();
            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].Width = 100;
            dgv.Columns["CodigoBarra"].HeaderText = "Codigo";
            dgv.Columns["CodigoBarra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Articulo";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["IvaStr"].Visible = true;
            dgv.Columns["IvaStr"].Width = 100;
            dgv.Columns["IvaStr"].HeaderText = "Iva";
            dgv.Columns["IvaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["PrecioStr"].Visible = true;
            dgv.Columns["PrecioStr"].Width = 120;
            dgv.Columns["PrecioStr"].HeaderText = "Precio";
            dgv.Columns["PrecioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 120;
            dgv.Columns["Cantidad"].HeaderText = "Cantidad";
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["SubTotalStr"].Visible = true;
            dgv.Columns["SubTotalStr"].Width = 120;
            dgv.Columns["SubTotalStr"].HeaderText = "Sub-Total";
            dgv.Columns["SubTotalStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarPie()
        {
            txtTotal.Text = _detalleCompra.TotalStr;
        }

        private void LimpiarNuevaCompra()
        {
            _detalleCompra = new CompraView();

            CargarDatosCuerpo();
            txtNroComprobante.Clear();
            CargarPie();
            LimpiarParaNuevoItem();
        }

        private void LimpiarParaNuevoItem()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecioUnitario.Clear();
            txtSubTotalLinea.Clear();
            nudCantidad.Value = 1;
            _articuloSeleccionado = null;
            txtCodigo.Focus();
        }

        private void AgregarItem(ArticuloCompraDto articulo, decimal cantidad)
        {
            _detalleCompra.Items.Add(AsignarDatosItem(articulo, cantidad));
        }


        private ItemCompraView AsignarDatosItem(ArticuloCompraDto articulo, decimal cantidad)
        {
            return new ItemCompraView
            {
                Descripcion = articulo.Descripcion,
                Iva = articulo.Iva,
                Precio = articulo.Precio,
                CodigoBarra = articulo.CodigoBarra,
                Cantidad = cantidad,
                ArticuloId = articulo.Id,
            };
        }

    }
}

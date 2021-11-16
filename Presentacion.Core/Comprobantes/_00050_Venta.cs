using Aplicacion.Constantes;
using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using IServicio.ListaPrecio;
using IServicio.ListaPrecio.DTOs;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicios.Articulo.DTOs;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using IServicios.PuestoTrabajo;
using Presentacion.Core.Articulo;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes.Clases;
using Presentacion.Core.Empleado;
using Presentacion.Core.FormaPago;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00050_Venta : FormBase
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IPuestoTrabajoServicio _puestoTrabajoServicio;        
        private readonly IContadorServicio _contadorServicio;
        private readonly IFacturaServicio _facturaServicio;

        private EmpleadoDto _vendedorSeleccionado;
        private ClienteDto _clienteSeleccionado;
        private ArticuloVentaDto _articuloSeleccionado;
        private ConfiguracionDto _configuracionDto;
        private FacturaView _factura;
        private ItemView _itemSeleccionado;

        private bool _permiteAgregarPorCantidad;
        private bool _articuloConPrecioAlternativo;
        private bool _autorizaPermisoListaPrecio;
        private bool _ingresoPorCodigoBascula;
        private bool _cambiarCantidadErrorValidacion;

        public _00050_Venta(IClienteServicio clienteServicio, IPuestoTrabajoServicio puestoTrabajoServicio, IListaPrecioServicio listaPrecioServicio, IConfiguracionServicio configuracionServicio, 
            IEmpleadoServicio empleadoServicio, IContadorServicio contadorServicio, IArticuloServicio articuloServicio, IFacturaServicio facturaServicio)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            _clienteServicio = clienteServicio;
            _empleadoServicio = empleadoServicio;
            _articuloServicio = articuloServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _configuracionServicio = configuracionServicio;
            _puestoTrabajoServicio = puestoTrabajoServicio;
            _contadorServicio = contadorServicio;
            _facturaServicio = facturaServicio;

            _vendedorSeleccionado = null;
            _clienteSeleccionado = null;
            _articuloSeleccionado = null;
            _cambiarCantidadErrorValidacion = false;

            _configuracionDto = _configuracionServicio.Obtener();
            if (_configuracionDto == null)
            {
                MessageBox.Show("Carge la configuracion del Sistema");
                Close();
            }

            _factura = new FacturaView();

            _articuloConPrecioAlternativo = false;
            _autorizaPermisoListaPrecio = false;
            _ingresoPorCodigoBascula = false;
            _permiteAgregarPorCantidad = false;

            txtCodigo.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoLetras(sender, args);
            };

        }

        // ========================================================== EVENTOS ==================================================================== //

        private void btnBuscarCliente_Click(object sender, System.EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
            fLookUpCliente.ShowDialog();

            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                _clienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                DatosCliente(_clienteSeleccionado);
            }
            else
            {
                _clienteSeleccionado = ObtenerCF();
                DatosCliente(_clienteSeleccionado);
            }
        }

        private void cmbListaPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CambiarTitulo();
        }

        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            var fLookUpVendedor = ObjectFactory.GetInstance<EmpleadoLookUp>();
            fLookUpVendedor.ShowDialog();

            if (fLookUpVendedor.EntidadSeleccionada != null)
            {
                _vendedorSeleccionado = (EmpleadoDto)
                fLookUpVendedor.EntidadSeleccionada;
                DatosEmpleado((EmpleadoDto)
                fLookUpVendedor.EntidadSeleccionada);

            }
            else
            {
                _vendedorSeleccionado = ObtenerVendedorLogin();
                DatosEmpleado(_vendedorSeleccionado);
            }
        }

        private void _00050_Venta_Load(object sender, EventArgs e)
        {
            CargarDatosCabecera();         
            CargarDatosCuerpo();
            CargarPie();
        }

        //private void cmbTipoComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    txtNroComprobante.Text = _contadorServicio.ObtenerSiguienteNumeroComprobante((TipoComprobante)cmbTipoComprobante.SelectedItem).ToString();
        //}

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            _factura.Descuento = nudDescuento.Value;
            CargarPie();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txtCodigo.Text.Contains("*"))
                    {
                        if (AsignarArticuloAlternativo(txtCodigo.Text))
                        {
                            btnAgregarArticulo.PerformClick();
                            return;
                        }
                    }

                    if (txtCodigo.Text.Length == 13)
                    {
                        if (_configuracionDto.ActivarBascula && _configuracionDto.ComienzoCodigo == decimal.Parse(txtCodigo.Text.Substring(0, 4)))
                        {
                            if (AsignarArticuloPorBascula(txtCodigo.Text))
                            {
                                btnAgregarArticulo.PerformClick();
                                return;
                            }
                        }
                        else
                        {
                            _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(txtCodigo.Text, (long)cmbListaPrecio.SelectedValue, _configuracionDto.DepositoIdVenta);
                        }
                    }
                    else
                    {
                        _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(txtCodigo.Text, (long)cmbListaPrecio.SelectedValue, _configuracionDto.DepositoIdVenta);
                    }

                    if (_articuloSeleccionado != null)
                    {
                        if (_permiteAgregarPorCantidad)
                        {
                            txtCodigo.Text = _articuloSeleccionado.CodigoBarra;
                            txtDescripcion.Text = _articuloSeleccionado.Descripcion;
                            txtPrecioUnitario.Text = _articuloSeleccionado.PrecioStr;
                            nudCantidad.Focus();
                            nudCantidad.Select(0, nudCantidad.Text.Length);
                            return;
                        }
                        else
                        {
                            btnAgregarArticulo.PerformClick();
                        }
                    }
                    else
                    {
                        LimpiarParaNuevoItem();
                    }
                }
            }

            e.Handled = false;
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 116:
                    _permiteAgregarPorCantidad = !_permiteAgregarPorCantidad;
                    nudCantidad.Enabled = _permiteAgregarPorCantidad;
                    break;
                case 119:
                    var fLookUpArticulo = new ArticuloLookUp((long)cmbListaPrecio.SelectedValue);
                    fLookUpArticulo.ShowDialog();

                    if (fLookUpArticulo.EntidadSeleccionada != null)
                    {
                        _articuloSeleccionado = (ArticuloVentaDto)fLookUpArticulo.EntidadSeleccionada;

                        if (_permiteAgregarPorCantidad)
                        {
                            txtCodigo.Text = _articuloSeleccionado.CodigoBarra;
                            txtDescripcion.Text = _articuloSeleccionado.Descripcion;
                            txtPrecioUnitario.Text = _articuloSeleccionado.PrecioStr;
                            nudCantidad.Focus();
                            nudCantidad.Select(0, nudCantidad.Text.Length);
                            return;
                        }
                        else
                        {
                            btnAgregarArticulo.PerformClick();
                        }
                    }
                    else
                    {
                        LimpiarParaNuevoItem();
                    }

                    break;
                default:
                    break;
            }
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregarArticulo.PerformClick();
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (_articuloSeleccionado != null)
            {
                var listaPrecioSeleccionada = (ListaPrecioDto)cmbListaPrecio.SelectedItem;
                if (listaPrecioSeleccionada.NecesitaAutorizacion)
                {
                    if (!_autorizaPermisoListaPrecio)
                    {
                        var fAutorizacion = ObjectFactory.GetInstance<AutorizacionListaDePrecio>();
                        fAutorizacion.ShowDialog();

                        if (!fAutorizacion.PermisoAutorizado) return;

                        _autorizaPermisoListaPrecio = fAutorizacion.PermisoAutorizado;
                        AgregarItem(_articuloSeleccionado, (long)cmbListaPrecio.SelectedValue, nudCantidad.Value);
                    }
                    else
                    {
                        AgregarItem(_articuloSeleccionado, (long)cmbListaPrecio.SelectedValue, nudCantidad.Value);
                    }
                }
                else
                {
                    AgregarItem(_articuloSeleccionado, (long)cmbListaPrecio.SelectedValue, nudCantidad.Value);
                }       
            }

            LimpiarParaNuevoItem();
            CargarDatosCuerpo();
            CargarPie();
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Seguro que quiere eliminar el articulo Seleccionado?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _factura.Items.Remove(_itemSeleccionado);
                CargarDatosCuerpo();
                CargarPie();
                LimpiarParaNuevoItem();
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _itemSeleccionado = (ItemView)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

            }
            else
            {
                MessageBox.Show("No hay articulos Cargados");
                _itemSeleccionado = null;
            }
        }

        private void btnCambiarCantidad_Click(object sender, EventArgs e)
        {
            var aRespaldo = _itemSeleccionado;
            var cantidad = _itemSeleccionado.Cantidad;

            if (aRespaldo.EsArticuloAlternativo|| aRespaldo.IngresoPorBascula)
            {
                MessageBox.Show("No se puede cambiar la cantidad del articulo");
                return;
            }

            if (_itemSeleccionado == null) return;
            var fCambiarCantidad = new CambiarCantidad(_itemSeleccionado);
            fCambiarCantidad.ShowDialog();

            if (fCambiarCantidad.Item != null)
            {
                var item = _factura.Items.FirstOrDefault(x => x.Id == fCambiarCantidad.Item.Id);

                _factura.Items.Remove(item);

                if (fCambiarCantidad.Item.Cantidad > 0)
                {
                    _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(_itemSeleccionado.CodigoBarra, _itemSeleccionado.ListaPrecioId, _configuracionDto.DepositoIdVenta);

                    nudCantidad.Value = fCambiarCantidad.Item.Cantidad;

                    btnAgregarArticulo.PerformClick();

                    if (_cambiarCantidadErrorValidacion)
                    {
                        aRespaldo.Cantidad = cantidad;

                        _factura.Items.Add(aRespaldo);
                        _cambiarCantidadErrorValidacion = false;
                    }
                }

                CargarDatosCuerpo();
                CargarPie();
                LimpiarParaNuevoItem();
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count <= 0)
                return;
            var aRespaldo = _itemSeleccionado;
            var cantidad = _itemSeleccionado.Cantidad;

            if (aRespaldo.EsArticuloAlternativo || aRespaldo.IngresoPorBascula)
            {
                MessageBox.Show("No se puede cambiar la cantidad del articulo");
                return;
            }

            if (_itemSeleccionado == null) return;
            var fCambiarCantidad = new CambiarCantidad(_itemSeleccionado);
            fCambiarCantidad.ShowDialog();

            if (fCambiarCantidad.Item != null)
            {
                var item = _factura.Items.FirstOrDefault(x => x.Id == fCambiarCantidad.Item.Id);

                _factura.Items.Remove(item);

                if (fCambiarCantidad.Item.Cantidad > 0)
                {
                    _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(_itemSeleccionado.CodigoBarra, _itemSeleccionado.ListaPrecioId, _configuracionDto.DepositoIdVenta);

                    nudCantidad.Value = fCambiarCantidad.Item.Cantidad;

                    btnAgregarArticulo.PerformClick();

                    if (_cambiarCantidadErrorValidacion)
                    {
                        aRespaldo.Cantidad = cantidad;

                        _factura.Items.Add(aRespaldo);
                        _cambiarCantidadErrorValidacion = false;
                    }
                }

                CargarDatosCuerpo();
                CargarPie();
                LimpiarParaNuevoItem();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count > 0)
            {
                if (MessageBox.Show("Ha cargado elementos. Desea Eliminarlos?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _factura = new FacturaView();

                    CargarDatosCuerpo();
                    CargarPie();
                    LimpiarParaNuevoItem();
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            _factura.Cliente = _clienteSeleccionado;
            _factura.Vendedor = _vendedorSeleccionado;
            _factura.UsuarioId = Identidad.UsuarioId;
            _factura.PuntoVentaId = (long)cmbPuestoVenta.SelectedValue;
            _factura.TipoComprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem;

            if (_configuracionDto.PuestoCajaSeparado)
            {
                try
                {
                    var nuevoComprobante= new FacturaDto()
                    {
                        EmpleadoId= _factura.Vendedor.Id,
                        UsuarioId= _factura.UsuarioId,
                        ClienteId= _factura.Cliente.Id,                        
                        TipoComprobante = _factura.TipoComprobante,
                        Estado= Estado.Pendiente,
                        PuestoTrabajoId= _factura.PuntoVentaId,
                        Fecha=DateTime.Now,
                        Descuento=_factura.Descuento,
                        SubTotal= _factura.SubTotal,
                        Total=_factura.Total,
                        VieneDeVentas= true,
                        Iva105=0,
                        Iva21=0,
                        Eliminado= false
                    };

                    foreach (var items in _factura.Items)
                    {
                        nuevoComprobante.Items.Add(new DetalleComprobanteDto
                        {
                            ArticuloId= items.ArticuloId,
                            Descripcion= items.Descripcion,
                            Codigo=items.CodigoBarra,
                            Cantidad= items.Cantidad,
                            Precio= items.Precio,
                            SubTotal= items.SubTotal,
                            Iva=items.Iva,
                            Eliminado= false
                        });
                    }

                    _facturaServicio.Insertar(nuevoComprobante);
                    MessageBox.Show("Los datos se grabaron correctamnete");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                var fFormaPago = new _00044_FormaPago(_factura);
                fFormaPago.ShowDialog();

                if (fFormaPago.RealizoVenta)
                {
                    MessageBox.Show("El cobro se realizo con exito");
                    
                }
            }

            var reportFactura = new FormReport();
            reportFactura.Invoice.Add(_factura);
            reportFactura.Detail = _factura.Items;
            reportFactura.Show();
            LimpiarNuevaFactura();
        }

        // ========================================================== METODOS ==================================================================== //

        private void CargarDatosCabecera()
        {
            _clienteSeleccionado = ObtenerCF();
            DatosCliente(_clienteSeleccionado);

            //==================================================================================================//

            PoblarComboBox(cmbTipoComprobante, Enum.GetValues(typeof(TipoComprobante)));
            cmbTipoComprobante.SelectedItem = TipoComprobante.B;

            PoblarComboBox(cmbPuestoVenta, _puestoTrabajoServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            if (cmbPuestoVenta.Items.Count == 0)
            {
                MessageBox.Show("Cargue los Puntos de venta");
                Close();
            }
            CambiarTitulo();

            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            if (cmbListaPrecio.Items.Count == 0)
            {
                MessageBox.Show("Cargue las Listas dePrecio");
                Close();
            }
            cmbListaPrecio.SelectedValue = _configuracionDto.ListaPrecioPorDefectoId;

            _vendedorSeleccionado = ObtenerVendedorLogin();
            DatosEmpleado(_vendedorSeleccionado);  

            lblFechaActual.Text = DateTime.Today.ToShortDateString();
        }

        private ClienteDto ObtenerCF()
        {
            var cliente= (ClienteDto) _clienteServicio.Obtener(typeof(ClienteDto), Aplicacion.Constantes.Cliente.ConsumidorFinalId);

            if (cliente == null)
            {
                MessageBox.Show("No se encotro el Cliente por Defecto");
            }

            return cliente;
        }

        private EmpleadoDto ObtenerVendedorLogin()
        {
            return (EmpleadoDto) _empleadoServicio.Obtener(typeof(EmpleadoDto), Identidad.EmpleadoId);
        }

        private void DatosEmpleado(EmpleadoDto empleado)
        {
            txtVendedor.Text = empleado.ApyNom;            
        }

        private void DatosCliente(ClienteDto cliente)
        {
            txtDomicilio.Text = cliente.Direccion;
            txtNombre.Text = cliente.ApyNom;
            txtDni.Text = cliente.Dni;
            txtCondicionIva.Text = cliente.CondicionIva;
            txtTelefono.Text = cliente.Telefono;
        }

        private void CambiarTitulo()
        {
            this.Text = $"TPV - {cmbPuestoVenta.Text}";
        }

        private void CargarDatosCuerpo()
        {
            dgvGrilla.DataSource = _factura.Items.ToList();
            FormatearGrilla(dgvGrilla);

            if (_factura.Items.Any())
            {
                var ultimoItem = _factura.Items.Last();
                lblDescripcion.Text = ultimoItem.Descripcion.ToUpper();
                lblPrecioPorCantidad.Text = $"{ultimoItem.Cantidad} X {ultimoItem.PrecioStr} = {ultimoItem.SubTotalStr}";
            }
            else
            {
                lblDescripcion.Text = string.Empty;
                lblPrecioPorCantidad.Text = string.Empty;
            }
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
            txtSubTotal.Text = _factura.SubTotalStr;
            nudDescuento.Value = _factura.Descuento;
            txtTotal.Text = _factura.TotalStr;
        } 

        private void LimpiarParaNuevoItem()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecioUnitario.Clear();
            nudCantidad.Value = 1;
            nudCantidad.Enabled = false;
            _permiteAgregarPorCantidad = false;
            _articuloConPrecioAlternativo = false;
            _ingresoPorCodigoBascula = false;
            _articuloSeleccionado = null;
            txtCodigo.Focus();
        }

        private bool AsignarArticuloAlternativo(string codigo)
        {
            _articuloConPrecioAlternativo = true;
            var codigoArticulo = codigo.Substring(0, codigo.IndexOf('*'));
            if (!string.IsNullOrEmpty(codigoArticulo))
            {
                _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(codigoArticulo, (long)cmbListaPrecio.SelectedValue, _configuracionDto.DepositoIdVenta);
                if (_articuloSeleccionado != null)
                {
                    var precioAlternativo = codigo.Substring(codigo.IndexOf('*')+ 1);

                    if (!string.IsNullOrEmpty(precioAlternativo))
                    {

                        if (decimal.TryParse(precioAlternativo, out decimal _precio))
                        {
                            _articuloSeleccionado.Precio = _precio;

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private bool AsignarArticuloPorBascula(string codigoBascula)
        {
            decimal _precioBascula = 0;
            decimal _pesoBascula = 0;
            _ingresoPorCodigoBascula = true;
            int.TryParse(codigoBascula.Substring(4, 3), out int codigoArticulo);
            var precioPesoArticulo = codigoBascula.Substring(7, 5);

            if (_configuracionDto.PrecioEnElCodigoBarras)
            {
                if (!decimal.TryParse(precioPesoArticulo.Insert(3, ","), NumberStyles.Number, new CultureInfo("es-Ar"), out _precioBascula))
                {
                    return false;
                }
            }
            else
            {
                if (!decimal.TryParse(precioPesoArticulo.Insert(2, ","), NumberStyles.Number, new CultureInfo("es-Ar"), out _pesoBascula))
                {
                    return false;
                }
            }
            _articuloSeleccionado = _articuloServicio.ObtenerAPorCodigo(codigoArticulo.ToString(), (long)cmbListaPrecio.SelectedValue, _configuracionDto.DepositoIdVenta);

            if (_articuloSeleccionado != null)
            {
                if (_configuracionDto.PrecioEnElCodigoBarras)
                {
                    _articuloSeleccionado.Precio = _precioBascula;
                }
                else
                {
                    nudCantidad.Value = _pesoBascula;
                }
            }
            return false;
        }

        private bool VerificarLimiteHorarioVenta(DateTime horaDesde, DateTime horaHasta)
        {
            var _horaDesdeSistena = DateTime.Now.Hour;
            var _minutoDesdeSistema = DateTime.Now.Minute;

            var _horaInicioDia = 0;
            var _minutoInicioDia = 0;

            var _horaFinDia = 23;
            var _minutoFinDia = 59;


            if (horaDesde <= horaHasta) 
            {
                if (_horaDesdeSistena >= horaDesde.Hour && _minutoDesdeSistema >= horaDesde.Minute)
                {
                    if (_horaDesdeSistena < horaHasta.Hour)
                    {
                        return true;
                    }
                    else if (_horaDesdeSistena == horaHasta.Hour && _minutoDesdeSistema <= horaHasta.Minute)
                    {
                        return true;
                    }
                }
            }
            else 
            {
                if (_horaDesdeSistena >= horaDesde.Hour)
                {
                    //=========================================================== Rango 1 =====================================================//

                    return _horaDesdeSistena >= horaDesde.Hour && _minutoDesdeSistema >= horaHasta.Minute && _horaDesdeSistena <= _horaFinDia && _minutoDesdeSistema <= _minutoFinDia;
                }
                else
                {
                    //=========================================================== Rango 2 =====================================================// 

                    if (_horaDesdeSistena >= _horaInicioDia && _minutoDesdeSistema >= _minutoInicioDia)
                    {
                        if (_horaDesdeSistena < horaHasta.Hour)
                        {
                            return true;
                        }
                        else if (_horaDesdeSistena == horaHasta.Hour && _minutoDesdeSistema <= horaHasta.Minute)
                        {
                           return true;
                        }
                    }
                }
            }

            return false; ;
        }

        private bool VerificarStock(long articuloId, decimal cantidad, decimal stock)
        {
            return stock >= cantidad + _factura.Items.Where(x => x.ArticuloId == articuloId).Sum(x => x.Cantidad);
        }

        private void LimpiarNuevaFactura()
        {
            _factura = new FacturaView();

            CargarDatosCuerpo();
            CargarPie();
            LimpiarParaNuevoItem();
        }

        private void AgregarItem(ArticuloVentaDto articulo, long listaPrecioId, decimal cantidad)
        {
            if (articulo.TieneRestriccionPorCantidad)
            {               
                var totalArticulosItems = _factura.Items.Where(x => x.ArticuloId == articulo.Id).Sum(x => x.Cantidad);

                if (cantidad + totalArticulosItems > articulo.Limite)
                {
                    _cambiarCantidadErrorValidacion = true;

                    var mensajeLimiteVenta = $"El articulo {articulo.Descripcion.ToUpper()} tiene una restricción"
                                  + Environment.NewLine
                                  + $"de Venta por una Cantidad Maxima de {articulo.Limite}.";

                    MessageBox.Show(mensajeLimiteVenta, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (articulo.TieneRestriccionHorario)
            {               

                if (VerificarLimiteHorarioVenta(articulo.HoraDesde, articulo.HoraHasta))
                {
                    _cambiarCantidadErrorValidacion = true;

                    var mensajeLimiteHorario = $"El articulo {articulo.Descripcion.ToUpper()} tiene una restricción"
                                             + Environment.NewLine
                                             + $"de Venta por horario entre {articulo.HoraDesde.ToShortTimeString()} hasta {articulo.HoraHasta.ToShortTimeString()}.";

                    MessageBox.Show(mensajeLimiteHorario, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (!articulo.PermiteStockNegativo)
            {               

                if (!VerificarStock(_articuloSeleccionado.Id, nudCantidad.Value, _articuloSeleccionado.Stock))
                {
                    _cambiarCantidadErrorValidacion = true;

                    var mensaje = $"No hay Stock para el articulo { _articuloSeleccionado.Descripcion}" + Environment.NewLine + $"Stock Actual:{ _articuloSeleccionado.Stock}";

                    MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _articuloSeleccionado = null;

                    txtCodigo.Clear();
                    txtCodigo.Focus();
                    return;
                }
            }

            if (_articuloConPrecioAlternativo || _ingresoPorCodigoBascula)
            {
                _factura.Items.Add(AsignarDatosItem(articulo, listaPrecioId, cantidad));
            }
            else
            {
                if (_configuracionDto.UnificarRenglonesIngresarMismoProducto)
                {
                    var item = _factura.Items.FirstOrDefault(x => x.ArticuloId == articulo.Id && x.ListaPrecioId == listaPrecioId && (!x.EsArticuloAlternativo && !x.IngresoPorBascula));

                    if (item == null || item.EsArticuloAlternativo || item.IngresoPorBascula) 
                    {
                        _factura.Items.Add(AsignarDatosItem(articulo, listaPrecioId, cantidad));
                    }
                    else
                    {
                        item.Cantidad += cantidad;
                    }
                }
                else
                {
                    _factura.Items.Add(AsignarDatosItem(articulo, listaPrecioId, cantidad));
                }
            }
        }

        private ItemView AsignarDatosItem(ArticuloVentaDto articulo, long listaPrecioId, decimal cantidad)
        {
            _factura.ContadorItems++;
            return new ItemView
            {
                Id= _factura.ContadorItems,
                Descripcion = articulo.Descripcion,
                Iva = articulo.Iva,
                Precio = articulo.Precio,
                CodigoBarra = articulo.CodigoBarra,
                Cantidad = cantidad,
                ListaPrecioId = listaPrecioId,
                ArticuloId = articulo.Id,
                EsArticuloAlternativo = _articuloConPrecioAlternativo,
                IngresoPorBascula = _ingresoPorCodigoBascula
            };
        }
      
    }
}
        

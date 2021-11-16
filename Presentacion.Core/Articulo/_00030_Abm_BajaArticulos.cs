using Aplicacion.Constantes;
using IServicio.Articulo.DTOs;
using IServicio.Deposito;
using IServicios.Articulo.DTOs;
using IServicios.BajaArticulo;
using IServicios.BajaArticulo.DTOs;
using IServicios.MotivoBaja;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00030_Abm_BajaArticulos : FormAbm
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        private readonly IDepositoSevicio _depositoSevicio;
        private readonly IBajaArticuloServicio _bajaArticuloServicio;

        private ArticuloVentaDto articulo;

        public _00030_Abm_BajaArticulos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _motivoBajaServicio = ObjectFactory.GetInstance<IMotivoBajaServicio>();
            PoblarComboBox(cmbMotivoBaja, _motivoBajaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

            _depositoSevicio = ObjectFactory.GetInstance<IDepositoSevicio>();
            PoblarComboBox(cmbDeposito, _depositoSevicio.Obtener(string.Empty, false), "Descripcion", "Id");

            _bajaArticuloServicio = ObjectFactory.GetInstance<IBajaArticuloServicio>();

            imgFotoArticulo.Image = Imagen.ImgBajaProductoPorDefecto;
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (BajaArticuloDto)_bajaArticuloServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }


                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else
            {
                btnEjecutar.Text = "Nuevo";
            }
        }

        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new BajaArticuloDto();
            nuevoRegistro.Articulo = txtArticulo.Text;
            nuevoRegistro.ArticuloId = articulo.Id;
            nuevoRegistro.MotivoBaja = cmbMotivoBaja.ToString();
            nuevoRegistro.MotivoBajaId = (long)cmbMotivoBaja.SelectedValue;
            nuevoRegistro.Observacion = txtObservacion.Text;
            nuevoRegistro.Fecha = DateTime.Now;
            nuevoRegistro.Cantidad = nudCantidadBaja.Value;

            _bajaArticuloServicio.Insertar(nuevoRegistro);
            _bajaArticuloServicio.ReduccionStock(articulo.Id, nudCantidadBaja.Value, (long)cmbDeposito.SelectedValue);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new BajaArticuloDto();
            modificarRegistro.Id = EntidadId.Value;
            modificarRegistro.Articulo = txtArticulo.Text;
            modificarRegistro.ArticuloId = articulo.Id;
            modificarRegistro.MotivoBajaId = (long)cmbMotivoBaja.SelectedValue;
            modificarRegistro.Observacion = txtObservacion.Text;
            modificarRegistro.Fecha = DateTime.Now;
            modificarRegistro.Cantidad = nudCantidadBaja.Value;

            _bajaArticuloServicio.Modificar(modificarRegistro);
        }

        public override void EjecutarComandoEliminar()
        {
            _bajaArticuloServicio.Eliminar(EntidadId.Value);
        }

        private void btnBuscarArticulo_Click(object sender, System.EventArgs e)
        {
            var fLookUpArticulo = new ArticuloLookUp(1);// [Arreglar]
            fLookUpArticulo.ShowDialog();

            if (fLookUpArticulo.EntidadSeleccionada!=null)
            {
                articulo = (ArticuloVentaDto)fLookUpArticulo.EntidadSeleccionada;

                txtArticulo.Text = articulo.Descripcion;
                nudStockActual.Value = articulo.Stock;
            }
        }

        private void btnNuevoMotivoBaja_Click(object sender, EventArgs e)
        {
            var form = new _00028_Abm_MotivoBaja(TipoOperacion.Nuevo);
            form.ShowDialog();

            if (form.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbMotivoBaja, _motivoBajaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtArticulo.Text)) return false;
            if (nudCantidadBaja.Value == 0) return false;
            if (nudStockActual.Value == 0) return false;
            if (nudStockActual.Value < nudCantidadBaja.Value)
            {
                MessageBox.Show("La cantidad de Baja no puese ser mayor al Stock Actual");
                nudStockActual.Value = 0;
                return false;
            }             
            return true;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult img = openFile.ShowDialog();
            imgFotoArticulo.Image = string.IsNullOrEmpty(openFile.FileName)
                  ? Imagen.ImgBajaProductoPorDefecto
                  : Image.FromFile(openFile.FileName);
        }
    }
}

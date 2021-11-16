using IServicio.Deposito;
using IServicio.Deposito.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Deposito
{
    public partial class _00055_Abm_Deposito : FormAbm
    {
        private readonly IDepositoSevicio _depositoSevicio;
        public _00055_Abm_Deposito(TipoOperacion tipoOperacion, long? entidadId = null)
             : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _depositoSevicio = ObjectFactory.GetInstance<IDepositoSevicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (DepositoDto)_depositoSevicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = resultado.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else 
            {
                btnEjecutar.Text = "Nuevo";
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text);
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _depositoSevicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new DepositoDto();
            nuevoRegistro.Descripcion = txtDescripcion.Text;
            nuevoRegistro.Ubicacion = txtUbicacion.Text;
            nuevoRegistro.Eliminado = false;

            _depositoSevicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new DepositoDto();
            modificarRegistro.Id = EntidadId.Value;
            modificarRegistro.Descripcion = txtDescripcion.Text;
            modificarRegistro.Ubicacion = txtUbicacion.Text;
            modificarRegistro.Eliminado = false;

            _depositoSevicio.Modificar(modificarRegistro);
        }


        public override void EjecutarComandoEliminar()
        {
            _depositoSevicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(Form formulario)
        {
            base.LimpiarControles(formulario);

            txtDescripcion.Focus();
        }
    }
}

using IServicios.PuestoTrabajo;
using IServicios.PuestoTrabajo.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00052_Abm_PuestoTrabajo : FormAbm
    {
        private readonly IPuestoTrabajoServicio _puestoTrabajoServicio;

        public _00052_Abm_PuestoTrabajo(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _puestoTrabajoServicio=ObjectFactory.GetInstance<IPuestoTrabajoServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var resultado = (PuestoTrabajoDto)_puestoTrabajoServicio.Obtener(entidadId.Value);

                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }

                txtCodigo.Text = resultado.Codigo.ToString();
                txtDescripcion.Text = resultado.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else 
            {
                btnEjecutar.Text = "Nuevo";
                LimpiarControles(this);
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            return !string.IsNullOrEmpty(txtDescripcion.Text);
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _puestoTrabajoServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new PuestoTrabajoDto();
            nuevoRegistro.Codigo = int.Parse(txtCodigo.Text);
            nuevoRegistro.Descripcion = txtDescripcion.Text;
            nuevoRegistro.Eliminado = false;

            _puestoTrabajoServicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new PuestoTrabajoDto();
            modificarRegistro.Id = EntidadId.Value;
            modificarRegistro.Descripcion = txtDescripcion.Text;
            modificarRegistro.Eliminado = false;

            _puestoTrabajoServicio.Modificar(modificarRegistro);
        }


        public override void EjecutarComandoEliminar()
        {
            _puestoTrabajoServicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(Form formulario)
        {
            base.LimpiarControles(formulario);

            txtCodigo.Clear();

            txtDescripcion.Focus();
        }
    }
}

using IServicio.CondicionIva.DTOs;
using IServicio.Departamento;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.CondicionIva
{
    public partial class _00014_Abm_CondicionIva : FormAbm
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00014_Abm_CondicionIva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (CondicionIvaDto)_condicionIvaServicio.Obtener(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocurrio un error al Obtener el registro seleccionado");
                    Close();
                }

                txtDescripcion.Text = entidad.Descripcion;
            }
            else
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _condicionIvaServicio.Insertar(new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoModificar()
        {
            _condicionIvaServicio.Modificar(new CondicionIvaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _condicionIvaServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            return true;
        }
    }
}

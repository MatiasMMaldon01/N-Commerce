using IServicio.UnidadMedida;
using IServicio.UnidadMedida.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00024_Abm_UnidadDeMedida : FormAbm
    {
        private readonly IUnidadMedidaServicio _unidadMedidaServicio;

        public _00024_Abm_UnidadDeMedida(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _unidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {

            if (entidadId.HasValue)
            {
                if (TipoOperacion==TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                }

                var entidad = (UnidadMedidaDto) _unidadMedidaServicio.Obtener(entidadId.Value);

                if (entidad==null)
                {
                    MessageBox.Show("Ocurrio un error al Obtener el registro seleccionado");
                    Close();
                }

            }
            else
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _unidadMedidaServicio.Insertar(new UnidadMedidaDto
            {
                Descripcion = txtDescripcion.Text
            }); ;
        }

        public override void EjecutarComandoModificar()
        {
            _unidadMedidaServicio.Modificar(new UnidadMedidaDto
            {
                Id=EntidadId.Value,
                Descripcion = txtDescripcion.Text
            }); ;
        }

        public override void EjecutarComandoEliminar()
        {
           _unidadMedidaServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                return false;
            }

            return true;
        }
    }
}

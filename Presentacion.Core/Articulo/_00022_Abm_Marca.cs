using IServicio.Marca;
using IServicio.Marca.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00022_Abm_Marca : FormAbm
    {
        private readonly IMarcaServicio _marcaServicio;

        public _00022_Abm_Marca(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (MarcaDto)_marcaServicio.Obtener(entidadId.Value);

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
            _marcaServicio.Insertar(new MarcaDto
            {
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoModificar()
        {
            _marcaServicio.Modificar(new MarcaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
            }); 
        }

        public override void EjecutarComandoEliminar()
        {
           _marcaServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            return true;
        }
    }
}

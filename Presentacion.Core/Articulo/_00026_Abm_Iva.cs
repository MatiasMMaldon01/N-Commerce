using IServicio.Iva;
using IServicio.Iva.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00026_Abm_Iva : FormAbm
    {
        private readonly IIvaServicio _ivaServicio;

        public _00026_Abm_Iva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (IvaDto)_ivaServicio.Obtener(entidadId.Value);

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
            _ivaServicio.Insertar(new IvaDto
            {
                Descripcion = txtDescripcion.Text,
                Porcentaje=nudPorcentaje.Value
            }); 
        }

        public override void EjecutarComandoModificar()
        {
            _ivaServicio.Modificar(new IvaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudPorcentaje.Value
            }); 
        }

        public override void EjecutarComandoEliminar()
        {
            _ivaServicio.Eliminar(EntidadId.Value);
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

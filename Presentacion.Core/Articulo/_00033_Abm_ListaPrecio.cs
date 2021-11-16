using IServicio.ListaPrecio;
using IServicio.ListaPrecio.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00033_Abm_ListaPrecio : FormAbm
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _00033_Abm_ListaPrecio(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _listaPrecioServicio = ObjectFactory.GetInstance<IListaPrecioServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (ListaPrecioDto)_listaPrecioServicio.Obtener(entidadId.Value);

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
            _listaPrecioServicio.Insertar(new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked
            });
        }

        public override void EjecutarComandoModificar()
        {
            _listaPrecioServicio.Modificar(new ListaPrecioDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia=nudPorcentaje.Value,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _listaPrecioServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            return true;
        }
    }

}

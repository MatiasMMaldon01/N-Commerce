using IServicio.Rubro;
using IServicio.Rubro.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00020_Abm_Rubro : FormAbm
    {
        private readonly IRubroServicio _rubroServicio;

        public _00020_Abm_Rubro(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue) 
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (RubroDto)_rubroServicio.Obtener(entidadId.Value);

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
            _rubroServicio.Insertar(new RubroDto
            {
                Descripcion = txtDescripcion.Text,
                ActivarHoraVenta= chkActivarHoraVenta.Checked,
                HoraLimiteVentaDesde= dtpHoraVentaDesde.Value,
                HoraLimiteVentaHasta= dtpHoraLimiteHasta.Value
            });
        }

        public override void EjecutarComandoModificar()
        {
            _rubroServicio.Modificar(new RubroDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraLimiteVentaDesde = dtpHoraVentaDesde.Value,
                HoraLimiteVentaHasta = dtpHoraLimiteHasta.Value
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _rubroServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            return true;
        }

        private void chkActivarHoraVenta_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkActivarHoraVenta.Checked == true)
            {
                dtpHoraVentaDesde.Enabled = true;
                dtpHoraLimiteHasta.Enabled = true;
            }
            else
            {
                dtpHoraVentaDesde.Enabled = false;
                dtpHoraLimiteHasta.Enabled = false;
            }
        }
    }
}

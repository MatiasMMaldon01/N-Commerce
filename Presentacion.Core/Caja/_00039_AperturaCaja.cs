using Aplicacion.Constantes;
using IServicio.Configuracion;
using IServicios.Caja;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00039_AperturaCaja : Form
    {
        public bool RealizoApertura { get;  set; } 

        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly ICajaServicio _cajaServicio;

        public _00039_AperturaCaja(IConfiguracionServicio configuracionServicio, ICajaServicio cajaServicio)
        {
            InitializeComponent();

            RealizoApertura = false;

            _configuracionServicio = configuracionServicio;
            _cajaServicio = cajaServicio;
        }

        private void _00039_AperturaCaja_Load(object sender, System.EventArgs e)
        {
            var configuracion = _configuracionServicio.Obtener();

            if (configuracion == null)
            {
                MessageBox.Show("Debe cargar la configuracion del Sistema");
                this.Close();
            }

            if (configuracion.IngresoManualCajaInicial)
            {
                nudMonto.Value = 0;
                nudMonto.Select(0, nudMonto.Text.Length);
                nudMonto.Focus();
            }
            else
            {
                var montoAnterior = _cajaServicio.ObtenerMontoCierre(Identidad.UsuarioId);
                nudMonto.Value = montoAnterior;
                nudMonto.Select(0, nudMonto.Text.Length);
                nudMonto.Focus();
            }
        }

        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            try
            {
                _cajaServicio.AbrirCaja(Identidad.UsuarioId, nudMonto.Value);
                RealizoApertura = true;
                MessageBox.Show("La caja se abrio correctamente");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RealizoApertura = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudMonto.Value = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            RealizoApertura = false;
            this.Close();
        }
    }
}

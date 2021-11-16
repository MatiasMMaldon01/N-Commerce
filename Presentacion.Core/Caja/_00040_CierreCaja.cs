using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00040_CierreCaja : FormBase
    {
        private readonly ICajaServicio _cajaServicio;
        private CajaDto caja;

        public _00040_CierreCaja()
        {
            InitializeComponent();

            _cajaServicio = ObjectFactory.GetInstance<ICajaServicio>();

            CargarDatos();
        }

        private void CargarDatos()
        {
            caja = _cajaServicio.Obtener(Identidad.UsuarioId);

            if (caja == null)
            {
                MessageBox.Show("Ocurrio un error al encontrar la Caja");
                Close();
            }
            
            txtCajaInicial.Text = caja.MontoAperturaStr;
            lblFechaApertura.Text = caja.FechaAperturaStr;
            txtTotalEfectivo.Text = (caja.Detalles.Where(x => x.TipoPago == TipoPago.Efectivo).Sum(x => x.Monto) + caja.MontoApertura).ToString("C");
            txtVentas.Text = caja.Detalles.Sum(x => x.Monto).ToString("C");
            txtTarjeta.Text = caja.Detalles.Where(x => x.TipoPago == TipoPago.Tarjeta).Sum(x => x.Monto).ToString("C");
            txtCheque.Text = caja.Detalles.Where(x => x.TipoPago == TipoPago.Cheque).Sum(x => x.Monto).ToString("C");
            txtCtaCte.Text = caja.Detalles.Where(x => x.TipoPago == TipoPago.CtaCte).Sum(x => x.Monto).ToString("C");
        }

        private void btnVerDetalleVenta_Click(object sender, EventArgs e)
        {
            var fComprobantesCaja = new ComprobantesCaja(caja.Comprobantes);
            fComprobantesCaja.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            var cajaCierre = caja.TotalEntradaEfectivo + caja.MontoApertura;
            _cajaServicio.CerrarCaja(caja.Id, cajaCierre);

            MessageBox.Show("La caja se cerro con Exito");
        }
    }
}

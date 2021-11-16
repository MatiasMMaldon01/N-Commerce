using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using PresentacionBase.Formularios;

namespace Presentacion.Core.FormaPago
{
    public partial class _00049_CobroDiferido : FormBase
    {
        private readonly IFacturaServicio _facturaServicio;
        private ComprobantesPendientesDto comprobanteSelec;
        private bool formularioCerrado = false;

        public _00049_CobroDiferido(IFacturaServicio facturaServicio)
        {
            InitializeComponent();
            _facturaServicio = facturaServicio;
            comprobanteSelec = null;
            CargarDatos();

            // Libreria para que refresque cada 60 seg la grilla
            // con las facturas que estan pendientes de pago.
            Observable.Interval(TimeSpan.FromSeconds(10))
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(_ => { CargarDatos(); });
        }

        private void CargarDatos()
        {
            dgvGrillaPedientePago.DataSource = null;
            dgvGrillaPedientePago.DataSource = _facturaServicio.ObtenerCPendientes();
            FormatearGrilla(dgvGrillaPedientePago);
            dgvGrillaDetalleComprobante.DataSource = new List<DetallePendienteDto>();
            nudTotal.Value = 0;
            FormatearGrillaDetalle(dgvGrillaDetalleComprobante);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            if (!formularioCerrado)
            {
                base.FormatearGrilla(dgv);

                dgv.Columns["NroComprobante"].Visible = true;
                dgv.Columns["NroComprobante"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["NroComprobante"].HeaderText = @"Nro de Comprobante";

                dgv.Columns["ClienteApyNom"].Visible = true;
                dgv.Columns["ClienteApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["ClienteApyNom"].HeaderText = @"Cliente";

                dgv.Columns["MontoPagarStr"].Visible = true;
                dgv.Columns["MontoPagarStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["MontoPagarStr"].HeaderText = @"Total";
            }
        }

        private void dgvGrillaPedientePago_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaPedientePago.RowCount > 0)
            {
                 comprobanteSelec = (ComprobantesPendientesDto)dgvGrillaPedientePago.Rows[e.RowIndex].DataBoundItem;

                if (comprobanteSelec!= null)
                {
                    nudTotal.Value = comprobanteSelec.MontoPagar;

                    dgvGrillaDetalleComprobante.DataSource = comprobanteSelec.Items.ToList();

                    FormatearGrillaDetalle(dgvGrillaDetalleComprobante);
                }
            }
        }

        private void FormatearGrillaDetalle(DataGridView dgv)
        {
            for (int i = 0; i < dgvGrillaDetalleComprobante.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            };

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Articulo";

            dgv.Columns["PrecioStr"].Visible = true;
            dgv.Columns["PrecioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["PrecioStr"].HeaderText = @"Precio";

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Cantidad"].HeaderText = @"Cantidad";
        }

        private void dgvGrillaPedientePago_DoubleClick(object sender, EventArgs e)
        {
            var fFormaPago = new _00044_FormaPago(comprobanteSelec);
            fFormaPago.ShowDialog();

            if (fFormaPago.RealizoVenta)
            {
                MessageBox.Show("El cobro se realizo con exito");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {            
            this.Close();
            GC.Collect();
        }

        private void _00049_CobroDiferido_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioCerrado = true;
        }
    }
}

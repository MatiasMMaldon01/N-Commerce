using IServicios.Caja.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class ComprobantesCaja : Form
    {
        private List<ComprobanteDeCajaDto> _comprobantes;

        public ComprobantesCaja(List<ComprobanteDeCajaDto> comprobantes)
        {
            InitializeComponent();
            _comprobantes = comprobantes;
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            dgvGrilla.DataSource = _comprobantes.ToList();
            FormatearGrilla(dgvGrilla);
        }

        private  void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            };

            dgv.Columns["Vendedor"].Visible = true;
            dgv.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Vendedor"].HeaderText = "Vendedor";
            dgv.Columns["Vendedor"].DisplayIndex = 0;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].DisplayIndex = 1;

            dgv.Columns["TipoComprobante"].Visible = true;
            dgv.Columns["TipoComprobante"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TipoComprobante"].HeaderText = "Tipo Comprobante";
            dgv.Columns["TipoComprobante"].DisplayIndex = 2;

            dgv.Columns["Total"].Visible = true;
            dgv.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["Total"].DisplayIndex = 3;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

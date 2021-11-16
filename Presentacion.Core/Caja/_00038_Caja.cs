using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00038_Caja : FormBase
    {
        private readonly ICajaServicio _cajaServicio;
        private CajaDto _cajaSeleccionada;

        public _00038_Caja(ICajaServicio cajaServicio)
        {
            InitializeComponent();
            _cajaServicio = cajaServicio;
            _cajaSeleccionada = null;
            ActualizarDatos();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (!_cajaServicio.VerificarSiEstaAbierta(Identidad.UsuarioId))
            {
                var fabrirCaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();
                fabrirCaja.ShowDialog();

                if (fabrirCaja.RealizoApertura)
                {
                    ActualizarDatos();
                }
            }
            else
            {
                MessageBox.Show($"Hay una caja abierta para este Usuario ({Identidad.Nombre} {Identidad.Apellido})", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ActualizarDatos()
        {
            dgvGrilla.DataSource = _cajaServicio.Obtener(txtBuscar.Text,chbFecha.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);

            FormatearGrilla (dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["UsuarioApertura"].Visible = true;
            dgv.Columns["UsuarioApertura"].Width = 200;
            dgv.Columns["UsuarioApertura"].HeaderText = "Usuario Apertura";
            dgv.Columns["UsuarioApertura"].DisplayIndex = 0;

            dgv.Columns["MontoAperturaStr"].Visible = true;
            dgv.Columns["MontoAperturaStr"].Width = 150;
            dgv.Columns["MontoAperturaStr"].HeaderText = "Monto Apertura";
            dgv.Columns["MontoAperturaStr"].DisplayIndex = 1;

            dgv.Columns["FechaAperturaStr"].Visible = true;
            dgv.Columns["FechaAperturaStr"].Width = 150;
            dgv.Columns["FechaAperturaStr"].HeaderText = "Fecha Apertura";
            dgv.Columns["FechaAperturaStr"].DisplayIndex = 2;

            dgv.Columns["UsuarioCierre"].Visible = true;
            dgv.Columns["UsuarioCierre"].Width = 200;
            dgv.Columns["UsuarioCierre"].HeaderText = "Usuario Cierre";
            dgv.Columns["UsuarioCierre"].DisplayIndex = 3;

            dgv.Columns["MontoCierreStr"].Visible = true;
            dgv.Columns["MontoCierreStr"].Width = 150;
            dgv.Columns["MontoCierreStr"].HeaderText = "Monto Cierre";
            dgv.Columns["MontoCierreStr"].DisplayIndex = 4;

            dgv.Columns["FechaCierreStr"].Visible = true;
            dgv.Columns["FechaCierreStr"].Width = 150;
            dgv.Columns["FechaCierreStr"].HeaderText = "Fecha Cierre";
            dgv.Columns["FechaCierreStr"].DisplayIndex = 5;

            //==============================================================================================//

            dgv.Columns["TotalEntradaEfectivoStr"].Visible = true;
            dgv.Columns["TotalEntradaEfectivoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalEntradaEfectivoStr"].HeaderText = "Efectivo Entrada";
            dgv.Columns["TotalEntradaEfectivoStr"].DisplayIndex = 6;

            dgv.Columns["TotalSalidaEfectivoStr"].Visible = true;
            dgv.Columns["TotalSalidaEfectivoStr"].Width = 80;
            dgv.Columns["TotalSalidaEfectivoStr"].HeaderText = "Efectivo Salida";
            dgv.Columns["TotalSalidaEfectivoStr"].DisplayIndex = 7;

            dgv.Columns["TotalEntradaTarjetaStr"].Visible = true;
            dgv.Columns["TotalEntradaTarjetaStr"].Width = 80;
            dgv.Columns["TotalEntradaTarjetaStr"].HeaderText = "Tarjeta Entrada";
            dgv.Columns["TotalEntradaTarjetaStr"].DisplayIndex = 8;

            dgv.Columns["TotalSalidaTarjetaStr"].Visible = true;
            dgv.Columns["TotalSalidaTarjetaStr"].Width = 80;
            dgv.Columns["TotalSalidaTarjetaStr"].HeaderText = "Tarjeta Salida";
            dgv.Columns["TotalSalidaTarjetaStr"].DisplayIndex = 9;

            dgv.Columns["TotalEntradaChequeStr"].Visible = true;
            dgv.Columns["TotalEntradaChequeStr"].Width = 80;
            dgv.Columns["TotalEntradaChequeStr"].HeaderText = "Cheque Entrada";
            dgv.Columns["TotalEntradaChequeStr"].DisplayIndex = 10;

            dgv.Columns["TotalSalidaChequeStr"].Visible = true;
            dgv.Columns["TotalSalidaChequeStr"].Width = 80;
            dgv.Columns["TotalSalidaChequeStr"].HeaderText = "Cheque Salida";
            dgv.Columns["TotalSalidaChequeStr"].DisplayIndex = 11;

            dgv.Columns["TotalEntradaCtaCteStr"].Visible = true;
            dgv.Columns["TotalEntradaCtaCteStr"].Width = 80;
            dgv.Columns["TotalEntradaCtaCteStr"].HeaderText = "Cta Cte Entrada";
            dgv.Columns["TotalEntradaCtaCteStr"].DisplayIndex = 12;

            dgv.Columns["TotalSalidaCtaCteStr"].Visible = true;
            dgv.Columns["TotalSalidaCtaCteStr"].Width = 80;
            dgv.Columns["TotalSalidaCtaCteStr"].HeaderText = "Cta Cte Salida";
            dgv.Columns["TotalSalidaCtaCteStr"].DisplayIndex = 13;
        }

        private void _00038_Caja_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.Rows.Count <= 0)
            {
                _cajaSeleccionada = null;
                return;
            }
                
            _cajaSeleccionada = (CajaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            var fCierreCaja = new _00040_CierreCaja();
            fCierreCaja.ShowDialog();

            ActualizarDatos();
        }
    }
}

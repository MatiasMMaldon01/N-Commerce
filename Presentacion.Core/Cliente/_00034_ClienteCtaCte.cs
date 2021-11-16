using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IServicio.Persona.DTOs;
using IServicios.CuentaCorriente;
using IServicios.CuentaCorriente.Dtos;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Cliente
{
    public partial class _00034_ClienteCtaCte : FormBase
    {

        private ClienteDto _clienteSeleccionado;
        private ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private CuentaCorrienteDto pagoSeleccionado;

        public _00034_ClienteCtaCte(ICuentaCorrienteServicio cuentaCorrienteServicio)
        {
            InitializeComponent();
            _cuentaCorrienteServicio = cuentaCorrienteServicio;

            _clienteSeleccionado = null;
            dgvGrilla.DataSource = new List<CuentaCorrienteDto>();
            FormatearGrilla(dgvGrilla);

            txtTotal.Text = 0.ToString("C");
            var primerDia = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1,0,0,0);
            dtpFechaDesde.Value = primerDia;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
            fLookUpCliente.ShowDialog();

            if (fLookUpCliente.EntidadSeleccionada!=null)
            {
                _clienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;

                txtApyNom.Text = _clienteSeleccionado.ApyNom;
                txtCelular.Text = _clienteSeleccionado.Telefono;
                txtDni.Text = _clienteSeleccionado.Dni;

                CargarDatos();

            }
            else
            {
                txtApyNom.Clear(); 
                txtCelular.Clear();
                txtDni.Clear();
                _clienteSeleccionado = null;
                dgvGrilla.DataSource = new List<CuentaCorrienteDto>();
            }
        }

        private void CargarDatos()
        {
            var resultado= _cuentaCorrienteServicio.Obtener(_clienteSeleccionado.Id, chbFiltroFecha.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
            dgvGrilla.DataSource = resultado;
            FormatearGrilla(dgvGrilla);

            txtTotal.Text = resultado.Sum(x => x.Monto).ToString("C");
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["fechaStr"].Visible = true;
            dgv.Columns["fechaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["fechaStr"].HeaderText = @"Fecha";

            dgv.Columns["HoraStr"].Visible = true;
            dgv.Columns["HoraStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["HoraStr"].HeaderText = @"Hora";

            dgv.Columns["MontoStr"].Visible = true;
            dgv.Columns["MontoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["MontoStr"].HeaderText = @"Monto";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRealizarPago_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado!=null)
            {
                var fPagoDeuda = new _00035_ClientePagoCtaCte(_clienteSeleccionado);
                fPagoDeuda.ShowDialog();

                if (fPagoDeuda.RealizoPago)
                {
                    CargarDatos();
                }
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                pagoSeleccionado = (CuentaCorrienteDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                MessageBox.Show("No hay Pagos cargados");
                pagoSeleccionado = null;
            }
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Seguro que quiere eliminar el pago Seleccionado?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _cuentaCorrienteServicio.CancelarPago(pagoSeleccionado.Id);
            }
        }
    }
}

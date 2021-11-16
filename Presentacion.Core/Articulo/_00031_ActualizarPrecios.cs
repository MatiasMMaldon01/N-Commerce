using IServicio.Articulo.DTOs;
using IServicio.ListaPrecio;
using IServicio.Marca;
using IServicio.Rubro;
using IServicios.ActualizarPrecio;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00031_ActualizarPrecios : FormBase
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IActualizarPrecioServicio _actualizarPrecioServicio;

        public _00031_ActualizarPrecios(IListaPrecioServicio listaPrecioServicio, IMarcaServicio marcaServicio, IRubroServicio rubroServicio, IActualizarPrecioServicio actualizarPrecioServicio)
        {
            InitializeComponent();

            _listaPrecioServicio = listaPrecioServicio;
            _marcaServicio = marcaServicio;
            _rubroServicio = rubroServicio;
            _actualizarPrecioServicio = actualizarPrecioServicio;

            PoblarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {

            if (ValidarCamposObligatorios())
            {
                DateTime fecha = dtpFecha.Value;
                bool marcaBool = chkMarca.Checked;
                long marcaId = (long)cmbMarca.SelectedValue;
                bool rubroBool = chkRubro.Checked;
                long rubroId = (long)cmbRubro.SelectedValue;
                bool articuloBool = chkArticulo.Checked;
                int codigoDesde = (int)nudCodigoDesde.Value;
                int codigoHasta = (int)(nudCodigoHasta.Value);
                bool listaPrecioBool = chkListaPrecio.Checked;
                long listaPrecioId = (long)cmbListaPrecio.SelectedValue;
                decimal valor = nudValor.Value;
                bool porcentaje = rdbPorcentaje.Checked;
                bool precio = RdbPrecio.Checked;

                _actualizarPrecioServicio.ActualizarPrecios(fecha, marcaBool, marcaId, rubroBool, rubroId, articuloBool, codigoDesde, codigoHasta,
                    listaPrecioBool, listaPrecioId, valor, porcentaje, precio);

                MessageBox.Show("El precio del Articulo se Actualizo correctamente");
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
            }
           
        }

        private bool ValidarCamposObligatorios()
        {
            if (nudValor.Value<=0) return false;
            if (dtpFecha.Value >= DateTime.Now)
            {
                MessageBox.Show("No puede ingresar una fecha anterior a la actual");
                dtpFecha.Value = DateTime.Now;
                return false;
            }

            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMarca_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkMarca.Checked == true)
            {
                cmbMarca.Enabled = true;
            }
            else
            {
                cmbMarca.Enabled = false;
            }
        }

        private void chkRubro_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkRubro.Checked == true)
            {
                cmbRubro.Enabled = true;
            }
            else
            {
                cmbRubro.Enabled = false;
            }
        }

        private void chkArticulo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkArticulo.Checked == true)
            {
                nudCodigoDesde.Enabled = true;
                nudCodigoHasta.Enabled = true;
            }
            else
            {
                nudCodigoDesde.Enabled = false;
                nudCodigoHasta.Enabled = false;
            }
        }

        private void chkListaPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkListaPrecio.Checked==true)
            {
                cmbListaPrecio.Enabled = true;
            }
            else
            {
                cmbListaPrecio.Enabled = false;
            }
        }
    }
}

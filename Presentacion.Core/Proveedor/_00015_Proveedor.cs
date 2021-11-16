using IServicios.Proveedores;
using IServicios.Proveedores.DTOs;
using PresentacionBase.Formularios;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Proveedor
{
    public partial class _00015_Proveedor : FormConsulta
    {
        private readonly IProveedoresServicio _proveedorServicio;

        public _00015_Proveedor(IProveedoresServicio proveedorServicio)
        {
            InitializeComponent();

            _proveedorServicio = proveedorServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = (List<ProveedoresDto>)_proveedorServicio.Obtener(cadenaBuscar, false);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["RazonSocial"].Visible = true;
            dgv.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["RazonSocial"].HeaderText = "Razon Social";
            dgv.Columns["RazonSocial"].DisplayIndex = 0;

            dgv.Columns["CUIL"].Visible = true;
            dgv.Columns["CUIL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["CUIL"].HeaderText = "CUIL";
            dgv.Columns["CUIL"].DisplayIndex = 1;

            dgv.Columns["Telefono"].Visible = true;
            dgv.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Telefono"].HeaderText = "Telefono";
            dgv.Columns["Telefono"].DisplayIndex = 2;

            dgv.Columns["Direccion"].Visible = true;
            dgv.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Direccion"].HeaderText = "Direccion";
            dgv.Columns["Direccion"].DisplayIndex = 4;

            dgv.Columns["Localidad"].Visible = true;
            dgv.Columns["Localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Localidad"].HeaderText = "Localidad";
            dgv.Columns["Localidad"].DisplayIndex = 5;

            dgv.Columns["Mail"].Visible = true;
            dgv.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Mail"].HeaderText = "E-Mail";
            dgv.Columns["Mail"].DisplayIndex = 6;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00016_Abm_Proveedor(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}

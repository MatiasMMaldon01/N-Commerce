using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class _00009_Cliente : FormConsulta
    {

        private readonly IClienteServicio _clienteServicio;

        public _00009_Cliente(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _clienteServicio.Obtener(typeof(ClienteDto), cadenaBuscar, false);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);


            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DisplayIndex = 0;

            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["Dni"].DisplayIndex = 1;

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

            dgv.Columns["CtaCteStr"].Visible = true;
            dgv.Columns["CtaCteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["CtaCteStr"].HeaderText = "Cta Cte";
            dgv.Columns["CtaCteStr"].DisplayIndex = 7;

            dgv.Columns["LimiteCompraStr"].Visible = true;
            dgv.Columns["LimiteCompraStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["LimiteCompraStr"].HeaderText = "Limite de Compra";
            dgv.Columns["LimiteCompraStr"].DisplayIndex = 8;

            dgv.Columns["MontoMaximoCtaCteStr"].Visible = true;
            dgv.Columns["MontoMaximoCtaCteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["MontoMaximoCtaCteStr"].HeaderText = "Monto Cta Cte";
            dgv.Columns["MontoMaximoCtaCteStr"].DisplayIndex = 9;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00010_Abm_Cliente(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}

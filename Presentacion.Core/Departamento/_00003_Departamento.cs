using System.Windows.Forms;
using IServicio.Departamento;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Departamento
{
    public partial class _00003_Departamento : FormConsulta
    {
        private readonly IDepartamentoServicio _departamentoServicio;

        public _00003_Departamento(IDepartamentoServicio departamentoServicio)
        {
            InitializeComponent();

            _departamentoServicio = departamentoServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _departamentoServicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Provincia"].Visible = true;
            dgv.Columns["Provincia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Provincia"].HeaderText = "Provincia";
            dgv.Columns["Provincia"].DisplayIndex = 0;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Departamento";
            dgv.Columns["Descripcion"].DisplayIndex = 1;
            
            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DisplayIndex = 2;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00004_Abm_Departamento(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}

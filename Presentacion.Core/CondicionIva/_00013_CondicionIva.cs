using IServicio.Departamento;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.CondicionIva
{
    public partial class _00013_CondicionIva : FormConsulta
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00013_CondicionIva(ICondicionIvaServicio condicionIvaServicio)
        {
            InitializeComponent();

            _condicionIvaServicio = condicionIvaServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {

            dgv.DataSource = _condicionIvaServicio.Obtener(cadenaBuscar);


            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00014_Abm_CondicionIva(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }

    }
}

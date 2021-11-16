using IServicio.Deposito;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Deposito
{
    public partial class _00054_Deposito : FormConsulta
    {
        private readonly IDepositoSevicio _depositoSevicio;

        public _00054_Deposito(IDepositoSevicio depositoSevicio)
        {
            InitializeComponent();

            _depositoSevicio = depositoSevicio;
        }
        
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            
            dgv.DataSource = _depositoSevicio.Obtener(cadenaBuscar);

            
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv); 

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["Ubicacion"].Visible = true;
            dgv.Columns["Ubicacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Ubicacion"].HeaderText = @"Ubicacion";

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00055_Abm_Deposito(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}

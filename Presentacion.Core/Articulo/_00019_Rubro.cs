using IServicio.Rubro;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00019_Rubro : FormConsulta
    {
        private readonly IRubroServicio _rubroServicio;

        public _00019_Rubro(IRubroServicio rubroServicio)
        {
            InitializeComponent();
            _rubroServicio = rubroServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            
            dgv.DataSource = _rubroServicio.Obtener(cadenaBuscar);

           
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv); 

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["ActivarHoraVentaStr"].Visible = true;
            dgv.Columns["ActivarHoraVentaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ActivarHoraVentaStr"].HeaderText = @"Limite Hora Venta";

            dgv.Columns["HoraLimiteDesdeStr"].Visible = true;
            dgv.Columns["HoraLimiteDesdeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["HoraLimiteDesdeStr"].HeaderText = @"Limite Desde";

            dgv.Columns["HoraLimiteHastaStr"].Visible = true;
            dgv.Columns["HoraLimiteHastaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["HoraLimiteHastaStr"].HeaderText = @"Limite Hasta";

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00020_Abm_Rubro(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}

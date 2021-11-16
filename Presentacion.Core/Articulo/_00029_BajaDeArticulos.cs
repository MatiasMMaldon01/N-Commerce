using IServicios.BajaArticulo;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00029_BajaDeArticulos : FormConsulta
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;

        public _00029_BajaDeArticulos(IBajaArticuloServicio bajaArticuloServicio)
        {
            InitializeComponent();

            _bajaArticuloServicio = bajaArticuloServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {

            dgv.DataSource = _bajaArticuloServicio.Obtener(string.Empty, false);


            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Articulo"].Visible = true;
            dgv.Columns["Articulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Articulo"].HeaderText = @"Articulo";

            dgv.Columns["MotivoBaja"].Visible = true;
            dgv.Columns["MotivoBaja"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["MotivoBaja"].HeaderText = @"Motivo De Baja";

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Fecha"].HeaderText = @"Fecha";

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Cantidad"].HeaderText = @"Cantidad De Baja";
           
            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00030_Abm_BajaArticulos(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}

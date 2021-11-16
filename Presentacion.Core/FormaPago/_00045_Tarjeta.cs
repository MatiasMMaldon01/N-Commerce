using IServicios.Tarjeta;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.FormaPago
{
    public partial class _00045_Tarjeta : FormConsulta
    {
        private readonly ITarjetaServicio _tarjetaServicio;
        public _00045_Tarjeta(ITarjetaServicio tarjetaServicio)
        {
            InitializeComponent();
            _tarjetaServicio = tarjetaServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _tarjetaServicio.Obtener(cadenaBuscar, false);

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
            var formulario = new _00046_Abm_tarjeta(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }

    }
}

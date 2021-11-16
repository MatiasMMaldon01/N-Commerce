using System.Windows.Forms;
using IServicio.Localidad;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Localidad
{
    public partial class _00005_Localidad : FormConsulta
    {
        private readonly ILocalidadServicio _localidadServicio;

        public _00005_Localidad(ILocalidadServicio localidadServicio)
        {
            InitializeComponent();

            _localidadServicio = localidadServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _localidadServicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            
            dgv.Columns["Provincia"].Visible = true;
            dgv.Columns["Provincia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Provincia"].HeaderText = "Provincia";
            dgv.Columns["Provincia"].DisplayIndex = 0;

            dgv.Columns["Departamento"].Visible = true;
            dgv.Columns["Departamento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Departamento"].HeaderText = "Departamento";
            dgv.Columns["Departamento"].DisplayIndex = 1;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Localidad";
            dgv.Columns["Descripcion"].DisplayIndex = 2;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DisplayIndex = 3;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00006_AbmLocalidad(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}

using IServicio.ListaPrecio;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00032_ListaPrecio : FormConsulta
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _00032_ListaPrecio(IListaPrecioServicio listaPrecioServicio)
        {
            InitializeComponent();
            _listaPrecioServicio = listaPrecioServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            
            dgv.DataSource = _listaPrecioServicio.Obtener(cadenaBuscar);

            
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv); 

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";
            dgv.Columns["Descripcion"].DisplayIndex = 0;

            dgv.Columns["PorcentajeGananciaStr"].Visible = true;
            dgv.Columns["PorcentajeGananciaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["PorcentajeGananciaStr"].HeaderText = @"Porcentaje de Ganancia";
            dgv.Columns["PorcentajeGananciaStr"].DisplayIndex = 1;

            dgv.Columns["AutorizacionStr"].Visible = true;
            dgv.Columns["AutorizacionStr"].Width= 100;
            dgv.Columns["AutorizacionStr"].HeaderText = @"Autorizacion";
            dgv.Columns["AutorizacionStr"].DisplayIndex = 2;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 3;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00033_Abm_ListaPrecio(tipoOperacion, id);

            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}

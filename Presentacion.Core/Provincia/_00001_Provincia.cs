using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IServicio.Provincia;
using IServicio.Provincia.DTOs;
using PresentacionBase.Formularios;

namespace Presentacion.Core.Provincia
{
    public partial class _00001_Provincia : FormConsulta
    {
        private readonly IProvinciaServicio _provinciaServicio; 

        public _00001_Provincia(IProvinciaServicio provinciaServicio)
        {
            InitializeComponent();

            _provinciaServicio = provinciaServicio;
        }

        // Sobreescribir el comportamiento del Actualizar
        // de la Clase Base (FormConsulta)
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            // Codigo agregado por Nosotros
            dgv.DataSource = _provinciaServicio.Obtener(cadenaBuscar, false);

            // Codigo del PAPA
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv); // Pongo Invisible las Columnas

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
            var formulario = new _00002_Abm_Provincia(tipoOperacion, id);
            
            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }
    }
}

using System;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormLookUp : FormBase
    {
        private long? entidadId;
        public object EntidadSeleccionada;

        public FormLookUp()
        {
            InitializeComponent();

            AsignarEvento_EnterLeave(this);
        }

        private void FormLookUp_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public virtual void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            FormatearGrilla(dgv);
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) return;

            entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;

            // Obtener el Objeto completo seleccionado
            EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            EntidadSeleccionada = null; 
            this.Close();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dgvGrilla_DoubleClick(object sender, System.EventArgs e)
        {
            this.Close();
        }


    }
}

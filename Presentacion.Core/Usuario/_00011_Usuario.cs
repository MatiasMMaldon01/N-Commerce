using IServicio.Usuario;
using IServicio.Usuario.DTOs;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Usuario
{
    public partial class _00011_Usuario : Form
    {

        protected UsuarioDto EmpleadoSeleccionado;

        private readonly IUsuarioServicio _usuarioServicio;

        public _00011_Usuario(IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();
            _usuarioServicio = usuarioServicio;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (EmpleadoSeleccionado == null)
                throw new Exception("Seleccione un Empleado");

            if (EmpleadoSeleccionado.NombreUsuario == "NO ASIGNADO")
            {
                _usuarioServicio.Crear(EmpleadoSeleccionado.EmpleadoId, EmpleadoSeleccionado.ApellidoEmpleado, EmpleadoSeleccionado.NombreEmpleado);

                if (MessageBox.Show("El usuario se creo correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    ActualizarDatos(dgvGrilla, string.Empty);
                }
            }
            else
            {
                MessageBox.Show("El usuario fue creado con anterioridad.");
            }

        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado == null)
                throw new Exception("Seleccione un Empleado");

            if (MessageBox.Show("Seguro que desea resetear la contrasena?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _usuarioServicio.ResetPassword(EmpleadoSeleccionado.Id);

            }
            
            if (MessageBox.Show($"La contrasena de {EmpleadoSeleccionado.ApyNomEmpleado} se reseteo correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado == null)
                throw new Exception("Seleccione un Empleado");

            if (MessageBox.Show("Seguro que desea bloquear el usuario?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _usuarioServicio.Bloquear(EmpleadoSeleccionado.Id);
            }


            if (MessageBox.Show($"El usuario {EmpleadoSeleccionado.ApyNomEmpleado} se Bloqueo correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        //======================================================================================================================//

        private void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _usuarioServicio.Obtener(cadenaBuscar, false);

            FormatearGrilla(dgvGrilla);
        }

        private  void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.Columns["ApyNomEmpleado"].Visible = true;
            dgv.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNomEmpleado"].DisplayIndex = 0;

            dgv.Columns["NombreUsuario"].Visible = true;
            dgv.Columns["NombreUsuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["NombreUsuario"].HeaderText = "Nombre de Usuario";
            dgv.Columns["NombreUsuario"].DisplayIndex = 1;

            dgv.Columns["EstaBloqueado"].Visible = true;
            dgv.Columns["EstaBloqueado"].Width = 100;
            dgv.Columns["EstaBloqueado"].HeaderText = "Esta Bloqueado";
            dgv.Columns["EstaBloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) EmpleadoSeleccionado=null;


            EmpleadoSeleccionado = (UsuarioDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                btnBuscar.PerformClick(); 
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
            txtBuscar.Clear();
            txtBuscar.Focus();
        }
    }
}

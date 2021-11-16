using Aplicacion.Constantes;
using IServicio.Seguridad;
using IServicio.Usuario;
using IServicio.Usuario.DTOs;
using System;
using System.Windows.Forms;
using static Aplicacion.Constantes.UsuarioAdmin;

namespace CommerceApp
{
    public partial class Login : Form
    {
        private bool ejecutoElBotonIngresar;
        private bool ejecutoElBotonCancelar;

        public bool puedeIngresarSistema;
        private UsuarioDto usuarioLogin;

        public bool PuedeIngresarSistema => puedeIngresarSistema;


        private readonly ISeguridadServicio _seguridadServicio;

        public Login(ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            _seguridadServicio = seguridadServicio;

            txtUsuario.Text = "mmartinezmaldonado";
            txtContraseña.Text = "M&MPass";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir del sistema", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ejecutoElBotonCancelar = true;
                puedeIngresarSistema = false;
                Application.Exit();
            };
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != string.Empty)
            {
                if (txtContraseña.Text != string.Empty)
                {
                    if (txtUsuario.Text == Usuario && txtContraseña.Text == Password)
                    {
                        ejecutoElBotonIngresar = true;
                        puedeIngresarSistema = true;
                        Close();
                    }
                    else if (_seguridadServicio.VerificarAcceso(txtUsuario.Text, txtContraseña.Text))
                    {
                        usuarioLogin = _seguridadServicio.ObtenerUsuarioLogin(txtUsuario.Text);
                        ejecutoElBotonIngresar = true;
                        puedeIngresarSistema = true;
                        Close();

                        Identidad.Apellido = usuarioLogin.ApellidoEmpleado;
                        Identidad.Nombre = usuarioLogin.NombreEmpleado;
                        Identidad.EmpleadoId = usuarioLogin.EmpleadoId;
                        Identidad.UsuarioId = usuarioLogin.Id;
                        Identidad.Usuario = usuarioLogin.NombreUsuario;
                        Identidad.Foto = usuarioLogin.FotoEmpleado;
                       
                    } else
                    {
                        MessageBox.Show("El usuario o la contraseña son incorrectos");
                        txtContraseña.Clear();
                        txtContraseña.Focus();
                    }
                }
                else
                {
                    lblError("Ingresar Contrasena");
                }
            }
            else
            {
                lblError("Ingresar Usuario");
            }

        }

        private void lblError(string error)
        {
            lblErrorMessage.Text = error;
            lblErrorMessage.Visible = true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ejecutoElBotonIngresar)
            {
                if (!ejecutoElBotonCancelar)
                {
                    btnSalir.PerformClick();
                }
            }
        }

        private void chbMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMostrarContrasena.Checked == true)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }

        }
    }
}

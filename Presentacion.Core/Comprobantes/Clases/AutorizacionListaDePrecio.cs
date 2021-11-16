using IServicio.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
    public partial class AutorizacionListaDePrecio : Form
    {
        private readonly ISeguridadServicio _seguridad;

        private bool _tienePermiso;
        public bool PermisoAutorizado => _tienePermiso;

        public AutorizacionListaDePrecio(ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            _seguridad = seguridadServicio;
            _tienePermiso = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                _tienePermiso = _seguridad.VerificarAcceso(txtUsuario.Text, txtContraseña.Text);

                if (_tienePermiso)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario o el Password son Icorrectos");
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _tienePermiso = false;
            Close();
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

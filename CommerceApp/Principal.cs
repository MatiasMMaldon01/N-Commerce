using System;
using System.Windows.Forms;
using Aplicacion.Constantes;
using IServicio.Configuracion;
using IServicios.Caja;
using Presentacion.Core.Articulo;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Configuracion;
using Presentacion.Core.Departamento;
using Presentacion.Core.Deposito;
using Presentacion.Core.Empleado;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Localidad;
using Presentacion.Core.Proveedor;
using Presentacion.Core.Provincia;
using Presentacion.Core.Usuario;
using StructureMap;

namespace CommerceApp
{
    public partial class Principal : Form
    {
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly ICajaServicio _cajaServicio;

        public Principal(IConfiguracionServicio configuracionServicio, ICajaServicio cajaServicio)
        {
            InitializeComponent();

            _configuracionServicio = configuracionServicio;
            _cajaServicio = cajaServicio;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //var nuevo = ObjectFactory.GetInstance<Login>();
            //nuevo.ShowDialog();
            lblNombre.Text = $"{Identidad.Apellido}, {Identidad.Nombre}";
            lblNUsuario.Text = $"{Identidad.Usuario}";
            lblAyuda.Text = "Si desea ver la Fecha y Hora" +Environment.NewLine+ "haga click en el Panel Contenedor";
            imgEmpleado.Image = Imagen.ConvertirImagen(Identidad.Foto);
        }

        private void panelContenedor_Click(object sender, EventArgs e)
        {
            lblFecha.Visible = true;
            lblHora.Visible = true;
        }

        private void tHoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void AbrirForm (object abrirForm)
        {
            if (this.panelContenedor.Controls.Count > 0)           
                lblFecha.Visible = false;
                lblHora.Visible = false;           

            Form fAbrir = abrirForm as Form;
            fAbrir.TopLevel = false;
            fAbrir.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fAbrir);
            this.panelContenedor.Tag = fAbrir;
            fAbrir.Show();            
        }

        //=================================================================================================================================//   
     
        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00001_Provincia>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00003_Departamento>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00005_Localidad>();
            AbrirForm(nuevo);
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00012_Configuracion>();
            AbrirForm(nuevo);
        }

        private void condicionIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00013_CondicionIva>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00019_Rubro>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00021_Marca>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00023_UnidadDeMedida>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00025_Iva>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00007_Empleado>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00009_Cliente>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00011_Usuario>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00017_Articulo>();
            AbrirForm(nuevo);
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00032_ListaPrecio>();
            AbrirForm(nuevo);
        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00054_Deposito>();
            AbrirForm(nuevo);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00017_Articulo>();
            AbrirForm(nuevo);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00009_Cliente>();
            AbrirForm(nuevo);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00007_Empleado>();
            AbrirForm(nuevo);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId!=0)
            {
                if (_configuracionServicio.VerificarSiExiste())
                {
                    if (_cajaServicio.VerificarSiEstaAbierta(Identidad.UsuarioId))
                    {
                        Form nuevo = ObjectFactory.GetInstance<_00050_Venta>();
                        AbrirForm(nuevo);
                    }
                    else
                    {
                        if (MessageBox.Show("No hay ninguna caja abierta. Desea abrir una?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            var faperturaCaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();
                            faperturaCaja.ShowDialog();

                            if (faperturaCaja.RealizoApertura)
                            {
                                Form nuevo = ObjectFactory.GetInstance<_00050_Venta>();
                                AbrirForm(nuevo);
                            }
                        }
                    }                   
                }
                else
                {
                    MessageBox.Show("Debe cargar la Configuracion del Sistema");
                }
            }
            else
            {
                MessageBox.Show("El usuario administrador no tiene acceso a esta area");
            }
           
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId != 0)
            {
                Form nuevo = ObjectFactory.GetInstance<_00053_Compra>();
                AbrirForm(nuevo);
            }
            else
            {
                MessageBox.Show("El usuario administrador no tiene acceso a esta area");
            }
        }

        private void consultaToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00029_BajaDeArticulos>();
            AbrirForm(nuevo);
        }

        private void puestoDeTrabajoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00051_PuestoTrabajo>();
            AbrirForm(nuevo);
        }

        private void motivoDeBajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00027_MotivoBaja>();
            AbrirForm(nuevo);
        }

        private void actualizarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00031_ActualizarPrecios>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00047_Banco>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00045_Tarjeta>();
            AbrirForm(nuevo);
        }

        private void consultaToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId != 0)
            {
                Form nuevo = ObjectFactory.GetInstance<_00038_Caja>();
                AbrirForm(nuevo);
            }
            else
            {
                MessageBox.Show("El usuario administrador no tiene acceso a esta area");
            }
        }

        private void cobroDiferidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId != 0)
            {
                Form nuevo = ObjectFactory.GetInstance<_00049_CobroDiferido>();
                AbrirForm(nuevo);
            }
            else
            {
                MessageBox.Show("El usuario administrador no tiene acceso a esta area");
            }
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId != 0)
            {
                Form nuevo = ObjectFactory.GetInstance<_00034_ClienteCtaCte>();
                AbrirForm(nuevo);
            }
            else
            {
                MessageBox.Show("El usuario administrador no tiene acceso a esta area");
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevo = ObjectFactory.GetInstance<_00015_Proveedor>();
            AbrirForm(nuevo);
        }
    }
}

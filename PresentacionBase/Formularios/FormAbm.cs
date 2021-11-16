using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormAbm : FormBase
    {
        protected long? EntidadId;
        protected TipoOperacion TipoOperacion;

        private bool _realizoAlgunaOperacion;
        public bool RealizoAlgunaOperacion => _realizoAlgunaOperacion;

        public FormAbm()
        {
            InitializeComponent();

            _realizoAlgunaOperacion = false;
        }

        public FormAbm(TipoOperacion tipoOperacion, long? entidadId = null)
            : this()
        {
            TipoOperacion = tipoOperacion;
            EntidadId = entidadId;
        }

        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    if (VerificarDatosObligatorios())
                    {
                        if (!VerificarSiExiste())
                        {
                            try
                            {
                                EjecutarComandoNuevo(); // Grabar
                                MessageBox.Show("Los datos se grabaron Correctamente");
                                LimpiarControles(this);
                                _realizoAlgunaOperacion = true;
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
                case TipoOperacion.Modificar:
                    if (VerificarDatosObligatorios())
                    {
                        if (!VerificarSiExiste(EntidadId))
                        {
                            try
                            {
                                EjecutarComandoModificar(); // Modificar
                                MessageBox.Show("Los datos se Modificaron Correctamente");
                                _realizoAlgunaOperacion = true;
                                this.Close();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
                case TipoOperacion.Eliminar:
                    if (VerificarDatosObligatorios())
                    {
                        if (!VerificarSiExiste(EntidadId))
                        {
                            try
                            {
                                EjecutarComandoEliminar(); // Modificar
                                MessageBox.Show("Los datos se Eliminaron Correctamente");
                                _realizoAlgunaOperacion = true;
                                this.Close();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
            }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Close();
            }
        }

        private void FormAbm_Load(object sender, EventArgs e)
        {
            CargarDatos(EntidadId);
        }

        public virtual void EjecutarComandoNuevo()
        {
        }

        public virtual void EjecutarComandoEliminar()
        {
        }

        public virtual void EjecutarComandoModificar()
        {
        }

        public virtual void LimpiarControles(Form formulario)
        {
            foreach (Control ctrl in formulario.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                }
            }
        }

        public virtual bool VerificarSiExiste(long? id = null)
        {
            return false;
        }

        public virtual bool VerificarDatosObligatorios()
        {
            return false;
        }

        public virtual void CargarDatos(long? entidadId)
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    btnEjecutar.Text = "Guardar";
                    break;
                case TipoOperacion.Modificar:
                    btnEjecutar.Text = "Modificar";
                    break;
                case TipoOperacion.Eliminar:
                    btnEjecutar.Text = "Eliminar";
                    break;
            }
        }
    }
}

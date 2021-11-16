using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicio.Provincia;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Cliente
{
    public partial class _00010_Abm_Cliente : FormAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;


        public _00010_Abm_Cliente(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            txtDni.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (ClienteDto)_clienteServicio.Obtener(typeof(ClienteDto), entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocuriro un error al obtener el registro seleciconado");
                    Close();
                }

                txtNombre.Text = entidad.Nombre;
                txtApellido.Text= entidad.Apellido;
                txtDni.Text=entidad.Dni;
                txtDomicilio.Text= entidad.Direccion;
                txtMail.Text=entidad.Mail;
                txtTelefono.Text=entidad.Telefono;
                chkLimiteCompra.Checked = entidad.TieneLimiteCompra;
                chkActivarCuentaCorriente.Checked = entidad.ActivarCtaCte;
                nudLimiteCompra.Value = entidad.MontoMaximoCtaCte;

                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
                cmbProvincia.SelectedValue = entidad.ProvinciaId;

                PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia(entidad.ProvinciaId),"Descripcion", "Id");
                cmbDepartamento.SelectedValue = entidad.DepartamentoId;

                PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento(entidad.DepartamentoId), "Descripcion", "Id");
                cmbLocalidad.SelectedValue = entidad.LocalidadId;

                PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
                cmbCondicionIva.SelectedValue = entidad.CondicionIvaId;
            }
            else
            {
                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                if (cmbProvincia.Items.Count > 0)
                {
                    PoblarComboBox(cmbDepartamento,_departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

                    if (cmbDepartamento.Items.Count > 0)
                    {
                        PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
                    }
                }

                PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtDomicilio.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _clienteServicio.Insertar(new ClienteDto
            {        
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                CondicionIvaId= (long) cmbCondicionIva.SelectedValue,
                ActivarCtaCte= chkActivarCuentaCorriente.Checked,
                TieneLimiteCompra= chkLimiteCompra.Checked,
                MontoMaximoCtaCte=nudLimiteCompra.Value
            });
        }

        public override void EjecutarComandoModificar()
        {
            _clienteServicio.Modificar(new ClienteDto
            {
                Id = EntidadId.Value,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
                ActivarCtaCte = chkActivarCuentaCorriente.Checked,
                TieneLimiteCompra = chkLimiteCompra.Checked,
                MontoMaximoCtaCte = nudLimiteCompra.Value
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _clienteServicio.Eliminar(typeof(ClienteDto), EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtApellido.Text)) return false;
            if (string.IsNullOrEmpty(txtNombre.Text)) return false;
            if (string.IsNullOrEmpty(txtDni.Text)) return false;
            if (string.IsNullOrEmpty(txtMail.Text)) return false;
            if (string.IsNullOrEmpty(txtTelefono.Text)) return false;
            if (string.IsNullOrEmpty(txtApellido.Text)) return false;
            if ((long)cmbProvincia.SelectedValue <= 0) return false;
            if ((long)cmbDepartamento.SelectedValue <= 0) return false;
            if ((long)cmbLocalidad.SelectedValue <= 0) return false;

            return true;
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count <= 0) return;

            PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

            if (cmbDepartamento.Items.Count <= 0) return;

            PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
        }

        private void cmbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDepartamento.Items.Count <= 0) return;

            PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00002_Abm_Provincia(TipoOperacion.Nuevo);

            fNuevaProvincia.ShowDialog();

            PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

            PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia(_provinciaServicio.Obtener(string.Empty, false).FirstOrDefault().Id), "Descripcion", "Id");
        }

        private void btnNuevoDepartamento_Click(object sender, EventArgs e)
        {
            var fNuevoDepartamento = new _00004_Abm_Departamento(TipoOperacion.Nuevo);

            fNuevoDepartamento.ShowDialog();

            if (cmbProvincia.Items.Count <= 0) return;

            PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

            PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento(_departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue).FirstOrDefault().Id), "Descripcion", "Id");
        }


        private void btnNuevaLocalidad_Click(object sender, EventArgs e)
        {
            var fNuevaLocalidad = new _00006_AbmLocalidad(TipoOperacion.Nuevo);

            fNuevaLocalidad.ShowDialog();

            if (cmbDepartamento.Items.Count <= 0) return;

            PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
        }

        private void btnNuevaCondicionIva_Click(object sender, EventArgs e)
        {
            var fCondicionIva = new _00014_Abm_CondicionIva(TipoOperacion.Nuevo);
            fCondicionIva.ShowDialog();

            PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

        private void chkActivarCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarCuentaCorriente.Checked==true)
            {
                nudLimiteCompra.Enabled = true;
                chkLimiteCompra.Enabled = true;
            }
            else
            {
                nudLimiteCompra.Enabled = false;
                chkLimiteCompra.Enabled = false;
            }
        }
    }
}

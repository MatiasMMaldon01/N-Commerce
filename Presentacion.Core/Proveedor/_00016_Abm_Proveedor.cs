using Aplicacion.Constantes;
using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Provincia;
using IServicios.Proveedores;
using IServicios.Proveedores.DTOs;
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

namespace Presentacion.Core.Proveedor
{
    public partial class _00016_Abm_Proveedor : FormAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IProveedoresServicio _proveedorServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00016_Abm_Proveedor(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _proveedorServicio = ObjectFactory.GetInstance<IProveedoresServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            txtCUIT.KeyPress += delegate (object sender, KeyPressEventArgs args)
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

                var entidad = (ProveedoresDto)_proveedorServicio.Obtener(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocuriro un error al obtener el registro seleciconado");
                    Close();
                }

                txtRazonSocial.Text = entidad.RazonSocial;
                txtCUIT.Text = entidad.CUIL;
                txtDomicilio.Text = entidad.Direccion;
                txtMail.Text = entidad.Mail;
                txtTelefono.Text = entidad.Telefono;

                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                cmbProvincia.SelectedValue = entidad.ProvinciaId;

                PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia(entidad.ProvinciaId), "Descripcion", "Id");

                cmbDepartamento.SelectedValue = entidad.DepartamentoId;

                PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento(entidad.DepartamentoId), "Descripcion", "Id");

                cmbLocalidad.SelectedValue = entidad.LocalidadId;

                PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(entidad.CondicionIvaId), "Descripcion", "Id");

                cmbCondicionIva.SelectedValue = entidad.CondicionIvaId;
            }
            else
            {

                var provincias = _provinciaServicio.Obtener(string.Empty, false);
                PoblarComboBox(cmbProvincia, provincias, "Descripcion", "Id");

                if (provincias.Any())
                {
                    var departamentos = _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                    PoblarComboBox(cmbDepartamento, departamentos, "Descripcion", "Id");

                    if (departamentos.Any())
                    {
                        var localidades = _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                        PoblarComboBox(cmbLocalidad, localidades, "Descripcion", "Id");
                    }
                }

                var condicionIva = _condicionIvaServicio.Obtener(string.Empty, false);

                PoblarComboBox(cmbCondicionIva, condicionIva, "Descripcion", "Id");

                txtRazonSocial.Clear();
                txtCUIT.Clear();
                txtDomicilio.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _proveedorServicio.Insertar(new ProveedoresDto
            {
                RazonSocial = txtRazonSocial.Text,
                CUIL = txtCUIT.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
            });
        }

        public override void EjecutarComandoModificar()
        {
            _proveedorServicio.Modificar(new ProveedoresDto
            {
                Id = EntidadId.Value,
                RazonSocial = txtRazonSocial.Text,
                CUIL = txtCUIT.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
            });
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text)) return false;
            if (string.IsNullOrEmpty(txtCUIT.Text)) return false;
            if (string.IsNullOrEmpty(txtMail.Text)) return false;
            if (string.IsNullOrEmpty(txtTelefono.Text)) return false;
            if ((long)cmbProvincia.SelectedValue <= 0) return false;
            if ((long)cmbDepartamento.SelectedValue <= 0) return false;
            if ((long)cmbLocalidad.SelectedValue <= 0) return false;
            if ((long)cmbCondicionIva.SelectedValue <= 0) return false;

            return true;
        }

        public override void EjecutarComandoEliminar()
        {
            _proveedorServicio.Eliminar(EntidadId.Value);
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
            var fNuevaCIva = new _00014_Abm_CondicionIva(TipoOperacion.Nuevo);

            fNuevaCIva.ShowDialog();

            if (cmbCondicionIva.Items.Count <= 0) return;

            PoblarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

    }

}


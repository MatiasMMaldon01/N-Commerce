using Aplicacion.Constantes;
using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicio.Provincia;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Empleado
{
    public partial class _00008_Abm_Empleado : FormAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IEmpleadoServicio _empleadoServicio;


        public _00008_Abm_Empleado(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            imgFoto.Image = Imagen.ImagenEmpleadoPorDefecto;

            _empleadoServicio = ObjectFactory.GetInstance<IEmpleadoServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            txtLegajo.Text = _empleadoServicio.ObtenerSiguienteLegajo().ToString();

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

                var entidad = (EmpleadoDto)_empleadoServicio.Obtener(typeof(EmpleadoDto), entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocuriro un error al obtener el registro seleciconado");
                    Close();
                }

                txtLegajo.Text = entidad.Legajo.ToString();
                txtNombre.Text = entidad.Nombre;
                txtApellido.Text = entidad.Apellido;
                txtDni.Text = entidad.Dni;
                txtDomicilio.Text = entidad.Direccion;
                txtMail.Text = entidad.Mail;
                txtTelefono.Text = entidad.Telefono;
                imgFoto.Image = Imagen.ConvertirImagen(entidad.Foto);

                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                cmbProvincia.SelectedValue = entidad.ProvinciaId;

                PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia(entidad.ProvinciaId),"Descripcion", "Id");

                cmbDepartamento.SelectedValue = entidad.DepartamentoId;

                PoblarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorDepartamento(entidad.DepartamentoId), "Descripcion", "Id");

                cmbLocalidad.SelectedValue = entidad.LocalidadId;
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

                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtDomicilio.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
                txtLegajo.Text = _empleadoServicio.ObtenerSiguienteLegajo().ToString();             
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _empleadoServicio.Insertar(new EmpleadoDto
            {
                Legajo = int.Parse(txtLegajo.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Foto=Imagen.ConvertirImagen(imgFoto.Image)
            });
        }

        public override void EjecutarComandoModificar()
        {
            _empleadoServicio.Modificar(new EmpleadoDto
            {
                Id=EntidadId.Value,
                Legajo = int.Parse(txtLegajo.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Foto = Imagen.ConvertirImagen(imgFoto.Image)
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _empleadoServicio.Eliminar(typeof(EmpleadoDto), EntidadId.Value);
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


        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult img = openFile.ShowDialog();

            imgFoto.Image = string.IsNullOrEmpty(openFile.FileName)
                    ? Imagen.ImagenEmpleadoPorDefecto
                    : Image.FromFile(openFile.FileName);

        }
    }
}

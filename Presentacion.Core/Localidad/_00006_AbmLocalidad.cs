using System.Linq;
using System.Windows.Forms;
using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Localidad.DTOs;
using IServicio.Provincia;
using IServicios.Localidad.DTOs;
using Presentacion.Core.Departamento;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Localidad
{
    public partial class _00006_AbmLocalidad : FormAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public _00006_AbmLocalidad(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (LocalidadDto)_localidadServicio.Obtener(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocuriro un error al obtener el registro seleciconado");
                    Close();
                }

                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                cmbProvincia.SelectedValue = entidad.ProvinciaId;

                PoblarComboBox(cmbDepartamento, _departamentoServicio.ObtenerPorProvincia(entidad.ProvinciaId), "Descripcion", "Id");

                cmbDepartamento.SelectedValue = entidad.DepartamentoId;

                txtDescripcion.Text = entidad.Descripcion;
            }
            else
            {
                // Nuevo
                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
                
                if (cmbProvincia.Items.Count > 0) // si tiene algo
                {
                    PoblarComboBox(cmbDepartamento,  _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");
                }

                txtDescripcion.Clear();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _localidadServicio.Insertar(new LocalidadCrudDto
            {
                Descripcion = txtDescripcion.Text,
                DepartamentoId = (long)cmbDepartamento.SelectedValue
            });
        }

        public override void EjecutarComandoModificar()
        {
            _localidadServicio.Modificar(new LocalidadCrudDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                DepartamentoId = (long)cmbDepartamento.SelectedValue
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _localidadServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            if (cmbProvincia.Items.Count <= 0)
                return false;

            if (cmbDepartamento.Items.Count <= 0)
                return false;

            return true;
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _localidadServicio.VerificarSiExiste(txtDescripcion.Text, (long) cmbDepartamento.SelectedValue, id);
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            PoblarComboBox(cmbDepartamento, 
                _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), 
                "Descripcion", 
                "Id");
        }

        private void btnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var formNuevaProvincia = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
            formNuevaProvincia.ShowDialog();

            if (formNuevaProvincia.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbProvincia,
                    _provinciaServicio.Obtener(string.Empty),
                    "Descripcion",
                    "Id");

                if (cmbProvincia.Items.Count > 0) // si tiene algo
                {
                    PoblarComboBox(cmbDepartamento,
                        _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue)
                        , "Descripcion",
                        "Id");
                }
            }
        }

        private void btnNuevoDepartamento_Click(object sender, System.EventArgs e)
        {
            var formNuevoDepartamento = new _00004_Abm_Departamento(TipoOperacion.Nuevo);
            formNuevoDepartamento.ShowDialog();

            if (formNuevoDepartamento.RealizoAlgunaOperacion)
            {
                if (cmbProvincia.Items.Count > 0) // si tiene algo
                {
                    PoblarComboBox(cmbDepartamento,
                        _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue)
                        , "Descripcion",
                        "Id");
                }
            }
        }
    }
}

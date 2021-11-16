using System.Windows.Forms;
using IServicio.Departamento;
using IServicio.Departamento.DTOs;
using IServicio.Provincia;
using IServicios.Departamento.DTOs;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Departamento
{
    public partial class _00004_Abm_Departamento : FormAbm
    {
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly IProvinciaServicio _provinciaServicio;


        public _00004_Abm_Departamento(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
        }

        public override void CargarDatos(long? entidadId)
        {
            PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false),"Descripcion","Id");

            if (entidadId.HasValue) // Eliminar o Modificar
            {
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                var entidad = (DepartamentoDto)_departamentoServicio.Obtener(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocurrio un error al Obtener el registro seleccionado");
                    Close();
                }


                txtDescripcion.Text = entidad.Descripcion;
                cmbProvincia.SelectedValue = entidad.ProvinciaId;
            }
            else
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _departamentoServicio.Insertar(new DepartamentoCrudDto{
                Descripcion = txtDescripcion.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue
            });
        }

        public override void EjecutarComandoModificar()
        {
            _departamentoServicio.Modificar(new DepartamentoCrudDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue
            });
        }

        public override void EjecutarComandoEliminar()
        {
            _departamentoServicio.Eliminar(EntidadId.Value);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            if (cmbProvincia.Items.Count <= 0)
                return false;

            return true;
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _departamentoServicio
                .VerificarSiExiste(txtDescripcion.Text, (long) cmbProvincia.SelectedValue, id);
        }

        private void btnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var formNuevaProvincia = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
            formNuevaProvincia.ShowDialog();

            if (formNuevaProvincia.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty, false),"Descripcion","Id");
            }
        }
    }
}

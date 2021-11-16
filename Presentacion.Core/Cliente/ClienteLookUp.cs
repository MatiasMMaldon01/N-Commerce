using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class ClienteLookUp : FormLookUp
    {
        private readonly IClienteServicio _clienteServicio;
        public ClienteLookUp(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {

            dgv.DataSource = _clienteServicio.Obtener(typeof(ClienteDto),cadenaBuscar, false);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DisplayIndex = 0;

            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["Dni"].DisplayIndex = 1;

            dgv.Columns["Telefono"].Visible = true;
            dgv.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Telefono"].HeaderText = "Telefono";
            dgv.Columns["Telefono"].DisplayIndex = 2;

            dgv.Columns["Direccion"].Visible = true;
            dgv.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Direccion"].HeaderText = "Direccion";
            dgv.Columns["Direccion"].DisplayIndex = 4;

            dgv.Columns["Localidad"].Visible = true;
            dgv.Columns["Localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Localidad"].HeaderText = "Localidad";
            dgv.Columns["Localidad"].DisplayIndex = 5;

            dgv.Columns["Mail"].Visible = true;
            dgv.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Mail"].HeaderText = "E-Mail";
            dgv.Columns["Mail"].DisplayIndex = 6;

        }



        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            if (EntidadSeleccionada == null)
                throw new Exception("Seleccione algun cliente");

        }
    }
}

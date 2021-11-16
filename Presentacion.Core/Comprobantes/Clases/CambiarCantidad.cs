using System;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
    public partial class CambiarCantidad : Form
    {
        private ItemView _itemSeleccionado;
        public ItemView Item => _itemSeleccionado;

        public CambiarCantidad(ItemView item)
        {
            InitializeComponent();
            _itemSeleccionado = item;
        }

        private void CambiarCantidad_Load(object sender, EventArgs e)
        {
            nudCantidad.Value = _itemSeleccionado.Cantidad;
            nudCantidad.Select(0, nudCantidad.Text.Length);
            lblArticulo.Text = _itemSeleccionado.Descripcion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _itemSeleccionado.Cantidad = nudCantidad.Value;
            this.Close();
        }
    }
}

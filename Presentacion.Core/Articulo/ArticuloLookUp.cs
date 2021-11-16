using IServicio.Articulo;
using IServicios.Articulo.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class ArticuloLookUp : FormLookUp
    {
        private readonly IArticuloServicio _articuloServicio;
        private long _listaDePrecio;

        public ArticuloLookUp(long listaDePrecioId)
        {
            InitializeComponent();

            _listaDePrecio = listaDePrecioId;
            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {

            dgv.DataSource = (List<ArticuloVentaDto>)_articuloServicio.ObtenerfLookUp(cadenaBuscar, _listaDePrecio);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);


            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].Width = 100;
            dgv.Columns["CodigoBarra"].HeaderText = "Codigo Barra";

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripcion";

            dgv.Columns["Iva"].Visible = true;
            dgv.Columns["Iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Iva"].HeaderText = @"Iva";

            dgv.Columns["PrecioStr"].Visible = true;
            dgv.Columns["PrecioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["PrecioStr"].HeaderText = @"Precio";

            dgv.Columns["Stock"].Visible = true;
            dgv.Columns["Stock"].Width = 100;
            dgv.Columns["Stock"].HeaderText = @"Stock";
            dgv.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            if (EntidadSeleccionada == null)
                throw new Exception("Seleccione algun articulo");

        }
    }
}

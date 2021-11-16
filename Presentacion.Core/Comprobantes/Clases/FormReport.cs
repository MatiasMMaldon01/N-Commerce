using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
    public partial class FormReport : Form
    {

        public List<FacturaView> Invoice = new List<FacturaView>();
        public List<ItemView> Detail = new List<ItemView>();

        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            reportViewer2.LocalReport.DataSources.Clear();
            //
            //Establezcamos los parámetros que enviaremos al reporte
            //recuerde que son dos para el titulo del reporte y para el nombre de la empresa
            //
            //
            //Establezcamos la lista como Datasource del informe
            //
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataFactura", Invoice));
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataDetalles", Detail));
            //
            //Enviemos la lista de parametros
            //
           reportViewer2.RefreshReport();
        }
    }
}

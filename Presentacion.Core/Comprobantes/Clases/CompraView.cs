using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Core.Comprobantes.Clases
{
    public class CompraView
    {

        public CompraView()
        {
            if (Items == null)
                Items = new List<ItemCompraView>();
        }

        //=============================  Cuerpo ==================================//
        public List<ItemCompraView> Items { get; set; }

        //=============================   Pie   ==================================//
        public decimal SubTotal => Items.Sum(x => x.SubTotal);
        public string SubTotalStr => SubTotal.ToString("C");
        public decimal Descuento { get; set; }
        public decimal Total => SubTotal - (SubTotal * (Descuento / 100m));
        public string TotalStr => Total.ToString("C");
    }
}

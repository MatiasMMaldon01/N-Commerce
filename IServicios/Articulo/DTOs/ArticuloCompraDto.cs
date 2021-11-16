using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Articulo.DTOs
{
    public class ArticuloCompraDto
    {
        public long Id { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public string PrecioStr => Precio.ToString("C");
        public decimal Stock { get; set; }
        public long ListaPrecioId { get; set; }
    }
}

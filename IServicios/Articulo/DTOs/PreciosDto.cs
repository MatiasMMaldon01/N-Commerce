using System;

namespace IServicios.Articulo.DTOs
{
    public class PreciosDto
    {
        public string ListaPrecio { get; set; }

        public decimal Precio { get; set; }

        public string PrecioStr => Precio.ToString("C");

        public DateTime Fecha { get; set; }

        public string FechaStr => Fecha.ToShortDateString();
    }
}

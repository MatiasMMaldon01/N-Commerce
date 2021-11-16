using IServicio.BaseDto;
using System;

namespace IServicios.Precios
{
    public class PreciosDto : DtoBase
    {
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal ListaPrecio { get; set; }
    }
}

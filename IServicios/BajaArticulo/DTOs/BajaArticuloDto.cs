using IServicio.BaseDto;
using System;

namespace IServicios.BajaArticulo.DTOs
{
    public class BajaArticuloDto : DtoBase
    {
        public string Articulo{ get; set; }

        public long ArticuloId { get; set; }

        public string MotivoBaja { get; set; }

        public long MotivoBajaId { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }
    }
}

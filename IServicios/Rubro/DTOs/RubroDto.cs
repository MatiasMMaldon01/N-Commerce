using IServicio.BaseDto;
using System;

namespace IServicio.Rubro.DTOs
{
    public class RubroDto : DtoBase
    {
        public string Descripcion { get; set; }

        public bool ActivarHoraVenta { get; set; }

        public string ActivarHoraVentaStr => ActivarHoraVenta ? "Si" : "No";

        public DateTime HoraLimiteVentaDesde { get; set; }
        public string HoraLimiteDesdeStr => ActivarHoraVenta ? HoraLimiteVentaDesde.ToShortTimeString() : "-----";

        public DateTime HoraLimiteVentaHasta { get; set; }
        public string HoraLimiteHastaStr => ActivarHoraVenta? HoraLimiteVentaHasta.ToShortTimeString(): "-----";
    }
}

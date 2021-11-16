using IServicio.BaseDto;
using System;

namespace IServicios.CuentaCorriente.Dtos
{
    public class CuentaCorrienteDto : DtoBase
    {
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string fechaStr => Fecha.ToShortDateString();
        public string HoraStr => Fecha.ToShortTimeString();

        public decimal Monto { get; set; }
        public string MontoStr => Monto.ToString("C");
    }
}

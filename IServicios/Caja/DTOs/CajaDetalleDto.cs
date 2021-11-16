using Aplicacion.Constantes;
using IServicio.BaseDto;

namespace IServicios.Caja.DTOs
{
    public class CajaDetalleDto : DtoBase
    {
        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }
    }
}

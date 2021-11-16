using Aplicacion.Constantes;
using IServicio.BaseDto;

namespace IServicios.Comprobante.DTOs
{
    public class FormaPagoDto : DtoBase
    {
        public TipoPago TipoPago { get; set; }
        public decimal Monto { get; set; }
    }
}

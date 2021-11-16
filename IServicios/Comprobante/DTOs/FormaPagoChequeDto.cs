using System;

namespace IServicios.Comprobante.DTOs
{
    public class FormaPagoChequeDto : FormaPagoDto
    {
        public long ClienteId { get; set; }
        public long BancoId { get; set; }
        public string Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}

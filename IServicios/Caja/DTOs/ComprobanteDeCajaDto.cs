using Aplicacion.Constantes;
using IServicio.BaseDto;
using System;

namespace IServicios.Caja.DTOs
{
    public class ComprobanteDeCajaDto : DtoBase
    {
        public string Vendedor { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
    }
}

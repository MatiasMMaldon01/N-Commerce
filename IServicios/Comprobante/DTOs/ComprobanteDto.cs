using Aplicacion.Constantes;
using IServicio.BaseDto;
using System;
using System.Collections.Generic;

namespace IServicios.Comprobante.DTOs
{
    public class ComprobanteDto : DtoBase
    {
        public ComprobanteDto()
        {
            if (Items == null)
                Items = new List<DetalleComprobanteDto>();

            if (FormasDePagos == null)
                FormasDePagos = new List<FormaPagoDto>();
        }
        public long EmpleadoId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal Iva21 { get; set; }
        public decimal Iva105 { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public List<DetalleComprobanteDto> Items { get; set; }
        public List<FormaPagoDto> FormasDePagos { get; set; }
    }

}

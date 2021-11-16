using IServicio.BaseDto;
using System.Collections.Generic;

namespace IServicios.Compras.DTOs
{
    public class CompraDto : DtoBase
    {
        public CompraDto()
        {
            if (Items == null)
                Items = new List<DetalleCompraDto>();
        }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public List<DetalleCompraDto> Items { get; set; }
    }
}

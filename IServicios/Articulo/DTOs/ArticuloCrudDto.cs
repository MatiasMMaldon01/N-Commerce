using IServicio.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Articulo.DTOs
{
    public class ArticuloCrudDto: DtoBase
    {
        public long MarcaId { get; set; }
        public long RubroId { get; set; }
        public long UnidadMedidaId { get; set; }
        public long IvaId { get; set; }
        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Ubicacion { get; set; }
        public bool ActivarLimiteVenta { get; set; }
        public decimal LimiteVenta { get; set; }
        public bool ActivarHoraVenta { get; set; }
        public DateTime HoraLimiteVentaDesde { get; set; }
        public DateTime HoraLimiteVentaHasta { get; set; }
        public bool PermiteStockNegativo { get; set; }
        public bool DescuentaStock { get; set; }
        public decimal StockMinimo { get; set; }
        public byte[] Foto { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal StockActual { get; set; }
    }
}

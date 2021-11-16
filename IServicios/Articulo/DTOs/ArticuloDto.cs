using System;
using System.Collections.Generic;
using System.Linq;
using IServicio.BaseDto;
using IServicios.Articulo.DTOs;

namespace IServicio.Articulo.DTOs
{
    public class ArticuloDto : DtoBase
    {
        public ArticuloDto()
        {
            if (Stocks == null)
                Stocks = new List<StockDepositoDto>();

            if (Precios == null)
                Precios = new List<PreciosDto>();
        }

        //-------------------------------------------//

        public long MarcaId { get; set; }
        public string Marca { get; set; }

        //-------------------------------------------//

        public long RubroId { get; set; }
        public string Rubro { get; set; }

        //-------------------------------------------//

        public long UnidadMedidaId { get; set; }
        public string UnidadMedida { get; set; }

        //-------------------------------------------//

        public long IvaId { get; set; }
        public string Iva { get; set; }

        //-------------------------------------------//

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

        // ==================================================== //
        // ===========    Stock del Articulo     ============== //
        // ==================================================== //


        public decimal StockActual => Stocks.Any()
            ? Stocks.Sum(x => x.Cantidad)
            : 0;

        public List<StockDepositoDto> Stocks { get; set; }

        public List<PreciosDto> Precios { get; set; }

    }
}

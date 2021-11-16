using IServicio.BaseDto;
using System;
using System.Collections.Generic;

namespace IServicios.Caja.DTOs
{
    public class CajaDto : DtoBase
    {

        public CajaDto()
        {
            if (Comprobantes == null)
                Comprobantes = new List<ComprobanteDeCajaDto>();

            if (Detalles == null)
                Detalles = new List<CajaDetalleDto>();
        }

        public long UsuarioAperturaId { get; set; }
        public string UsuarioApertura { get; set; }
        public decimal MontoApertura { get; set; }
        public string MontoAperturaStr => MontoApertura.ToString("C");
        public DateTime FechaApertura { get; set; }
        public string FechaAperturaStr => FechaApertura.ToShortDateString();

        // ==========================================//

        public long? UsuarioCierreId { get; set; }
        public string UsuarioCierre { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string FechaCierreStr => FechaCierre.HasValue ? FechaCierre.Value.ToShortDateString() : "----";
        public decimal? MontoCierre { get; set; }
        public string MontoCierreStr => MontoCierre.HasValue ? MontoCierre.Value.ToString("C") : "----";

        // ==========================================//

        public decimal TotalEntradaEfectivo { get; set; }
        public string TotalEntradaEfectivoStr => TotalEntradaEfectivo.ToString ("C");

        public decimal TotalSalidaEfectivo { get; set; }
        public string TotalSalidaEfectivoStr => TotalSalidaEfectivo.ToString("C");
        // ==========================================//

        public decimal TotalEntradaTarjeta { get; set; }
        public string TotalEntradaTarjetaStr => TotalEntradaTarjeta.ToString("C");
        public decimal TotalSalidaTarjeta { get; set; }
        public string TotalSalidaTarjetaStr => TotalSalidaTarjeta.ToString("C");

        // ==========================================//

        public decimal TotalEntradaCheque { get; set; }
        public string TotalEntradaChequeStr => TotalEntradaCheque.ToString("C");
        public decimal TotalSalidaCheque { get; set; }
        public string TotalSalidaChequeStr => TotalSalidaCheque.ToString("C");

        // ==========================================//

        public decimal TotalEntradaCtaCte { get; set; }
        public string TotalEntradaCtaCteStr => TotalEntradaCtaCte.ToString("C");
        public decimal TotalSalidaCtaCte { get; set; }
        public string TotalSalidaCtaCteStr => TotalSalidaCtaCte.ToString("C");

        // ==========================================//

        public List<CajaDetalleDto> Detalles { get; set; }

        public List<ComprobanteDeCajaDto> Comprobantes { get; set; }
    }
}

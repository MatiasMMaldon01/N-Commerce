using Aplicacion.Constantes;
using IServicio.BaseDto;
using IServicio.Persona.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.Comprobante.DTOs
{
    public class ComprobantesPendientesDto : DtoBase
    {
        public ComprobantesPendientesDto()
        {
            if (Items == null)
            {
                Items = new List<DetallePendienteDto>();
            }
        }

        public List<DetallePendienteDto> Items { get; set; }

        public int NroComprobante { get; set; }

        public ClienteDto Cliente { get; set; }

        public string ClienteApyNom { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public DateTime Fecha { get; set; }

        public decimal MontoPagar { get; set; }

        public string MontoPagarStr => MontoPagar.ToString("C");

    }
}

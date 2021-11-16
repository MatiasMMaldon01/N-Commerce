using IServicios.Comprobante.DTOs;
using System.Collections.Generic;

namespace IServicios.Comprobante
{
    public interface IFacturaServicio : IComprobanteServicio
    {
        IEnumerable<ComprobantesPendientesDto> ObtenerCPendientes();
    }
}

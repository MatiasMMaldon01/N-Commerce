using Aplicacion.Constantes;

namespace IServicios.Comprobante.DTOs
{
    public  class FacturaDto : ComprobanteDto
    {
        public long ClienteId { get; set; }
        public long PuestoTrabajoId { get; set; }
        public Estado Estado { get; set; }
        public bool VieneDeVentas { get; set; } = false;
    }
}

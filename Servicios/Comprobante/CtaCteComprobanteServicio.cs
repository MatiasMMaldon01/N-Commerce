using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;

namespace Servicios.Comprobante
{
    public class CtaCteComprobanteServicio : ComprobanteServicio, ICtaCteComprobanteServicio
    {
        public CtaCteComprobanteServicio(IUnidadDeTrabajo unidadDeTrabajo) 
            : base(unidadDeTrabajo)
        { 
        }

        public void Eliminar(long pagoId)
        {
            
        }
    }
}

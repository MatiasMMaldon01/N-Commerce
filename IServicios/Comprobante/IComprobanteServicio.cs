using IServicios.Comprobante.DTOs;

namespace IServicios.Comprobante
{
    public interface IComprobanteServicio
    {
        long Insertar(ComprobanteDto dto);
    }
}

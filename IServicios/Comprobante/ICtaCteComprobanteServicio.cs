namespace IServicios.Comprobante
{
    public interface ICtaCteComprobanteServicio : IComprobanteServicio
    {
        void Eliminar(long pagoId);
    }
}

using IServicio.BaseDto;

namespace IServicios.BajaArticulo
{
    public interface IBajaArticuloServicio : IServicio.Base.IServicio
    {
        void ReduccionStock(long articuloId,decimal cantidad, long? depositoId);
    }
}

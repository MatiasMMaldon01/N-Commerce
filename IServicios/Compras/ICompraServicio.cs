using IServicios.Compras.DTOs;

namespace IServicios.Compras
{
    public interface ICompraServicio
    {
        void IncrementarStock(CompraDto compra);
    }
}

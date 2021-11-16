using System;

namespace IServicios.ActualizarPrecio
{
    public interface IActualizarPrecioServicio
    {
        void ActualizarPrecios (DateTime fecha, bool marcaBool, long marcaId, bool rubroBool, long rubroId, bool articuloBool, int codigoDesde, int codigoHasta,
            bool listaPrecioBool, long listaPrecioId, decimal valor, bool porcentaje, bool precio);
    }
}

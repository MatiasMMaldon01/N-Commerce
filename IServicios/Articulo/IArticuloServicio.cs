using IServicios.Articulo.DTOs;
using System.Collections.Generic;

namespace IServicio.Articulo
{
    public interface IArticuloServicio : Base.IServicio
    {
        bool VerificarSiExiste(string text, long? id);
        int ObtenerSiguienteNroCodigo();

        int ObtenerCantidadArticulos();
        IEnumerable<ArticuloVentaDto> ObtenerfLookUp(string cadenaBuscar, long listaPrecioId);
        ArticuloVentaDto ObtenerAPorCodigo(string codigo, long listaPrecioId, long depositoId);
        ArticuloCompraDto ObtenerArticuloPorCodigo(string codigo);
    }
}

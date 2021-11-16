using System.Collections.Generic;
using IServicio.Localidad.DTOs;

namespace IServicio.Localidad
{
    public interface ILocalidadServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long idRelacional, long? entidadId = null);

        IEnumerable<LocalidadDto> ObtenerPorDepartamento(long departamentoId);
    }
}

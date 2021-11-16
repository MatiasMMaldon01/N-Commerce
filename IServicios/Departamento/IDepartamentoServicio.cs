using System.Collections.Generic;
using IServicio.Departamento.DTOs;

namespace IServicio.Departamento
{
    public interface IDepartamentoServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long idRelacional,  long? entidadId = null);

        IEnumerable<DepartamentoDto> ObtenerPorProvincia(long provinciaId);
    }
}

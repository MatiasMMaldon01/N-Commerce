using System.Collections.Generic;
using IServicio.BaseDto;

namespace IServicio.Base
{
    public interface IServicioConsulta
    {
        DtoBase Obtener(long id);

        IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos=true);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorio<TEntidad> where TEntidad : EntidadBase
    {
        // Metodos de Persistencia

        long Insertar(TEntidad entidad);

        void Eliminar(long entidadId);

        void Modificar(TEntidad entidad);


        // Metodos de Lectura

        TEntidad Obtener(long entidadId, string propiedadNavegacion = "");

        IEnumerable<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro = null, string propiedadesNavegacion = "");
    }
}

using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructura.Repositorio
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : EntidadBase
    {
        protected readonly DataContext _context;

        public Repositorio(DataContext context)
        {
            _context = context;
        }
        
        public void Eliminar(long entidadId)
        {
            var entidadEliminar = _context.Set<TEntidad>()
                .FirstOrDefault(x => x.Id == entidadId);

            if(entidadEliminar == null) throw new Exception("La entidad a eliminar no puede ser Null");

            entidadEliminar.EstaEliminado = !entidadEliminar.EstaEliminado;
        }

        public long Insertar(TEntidad entidad)
        {
            if(entidad == null) throw new Exception("La entidad a Insertar no puede ser NULL");

            _context.Set<TEntidad>().Add(entidad);

            return entidad.Id;
        }

        public void Modificar(TEntidad entidad)
        {
            if(entidad == null) throw new Exception("La entidad Modificar no puede ser NULL");

            _context.Set<TEntidad>().Attach(entidad);
            _context.Entry(entidad).State = EntityState.Modified;
        }

        public virtual TEntidad Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<TEntidad>>(_context.Set<TEntidad>(), (current, include) => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public virtual IEnumerable<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<TEntidad>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<TEntidad>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}

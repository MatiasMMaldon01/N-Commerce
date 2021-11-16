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
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        public EmpleadoRepositorio(DataContext dataContext) 
            : base(dataContext)
        {

        }

        public override Empleado Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Empleado>>(_context.Set<Persona>().OfType<Empleado>(), (current, include) 
                => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<Empleado> Obtener(Expression<Func<Empleado, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Persona>().OfType<Empleado>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Empleado>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}

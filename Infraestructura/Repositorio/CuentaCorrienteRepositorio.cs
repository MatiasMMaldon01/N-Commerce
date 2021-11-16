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
    public class CuentaCorrienteRepositorio : Repositorio<MovimientoCuentaCorriente>, ICuentaCorrienteRepositorio
    {
        public CuentaCorrienteRepositorio(DataContext dataContext)
           : base(dataContext)
        {
        }

        public override MovimientoCuentaCorriente Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<MovimientoCuentaCorriente>>(_context.Set<Movimiento>().OfType<MovimientoCuentaCorriente>(), (current, include) => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<MovimientoCuentaCorriente> Obtener(Expression<Func<MovimientoCuentaCorriente, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Movimiento>().OfType< MovimientoCuentaCorriente>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<MovimientoCuentaCorriente>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}

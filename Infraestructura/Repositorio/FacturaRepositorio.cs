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
    public class FacturaRepositorio : Repositorio<Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(DataContext context)
            :base(context)
        {
        }

        public override Factura Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Factura>>(_context.Set<Comprobante>().OfType<Factura>(), (current, include)
                => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<Factura> Obtener(Expression<Func<Factura, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Comprobante>().OfType<Factura>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Factura>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}

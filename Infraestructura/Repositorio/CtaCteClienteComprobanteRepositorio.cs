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
    public class CtaCteClienteComprobanteRepositorio : Repositorio<CuentaCorrienteCliente>, ICtaCteClienteComprobanteRepositorio
    {
        public CtaCteClienteComprobanteRepositorio(DataContext context)
            :base (context)
        {
        }

        public override CuentaCorrienteCliente Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<CuentaCorrienteCliente>>(_context.Set<Comprobante>().OfType<CuentaCorrienteCliente>(), (current, include)
                => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<CuentaCorrienteCliente> Obtener(Expression<Func<CuentaCorrienteCliente, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Comprobante>().OfType<CuentaCorrienteCliente>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<CuentaCorrienteCliente>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}

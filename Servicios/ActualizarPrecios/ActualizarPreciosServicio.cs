using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicios.ActualizarPrecio;
using Servicios.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Servicios.ActualizarPrecios
{
    public class ActualizarPreciosServicio : IActualizarPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ActualizarPreciosServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void ActualizarPrecios (DateTime fecha, bool marcaBool, long marcaId, bool rubroBool, long rubroId, bool articuloBool, int codigoDesde, int codigoHasta, 
            bool listaPrecioBool, long listaPrecioId, decimal valor, bool porcentaje, bool precio)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x => true;

                    if (marcaBool)
                    {
                        filtro = filtro.And(x => x.MarcaId == marcaId);
                    }

                    if (rubroBool)
                    {
                        filtro = filtro.And(x => x.RubroId == rubroId);
                    }

                    if (articuloBool)
                    {
                        filtro = filtro.And(x => x.Codigo >= codigoDesde && x.Codigo <= codigoHasta);
                    }

                    var articuloSeleccionado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Precios");

                    var listaPrecios = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener();

                    foreach (var articulo in articuloSeleccionado)
                    { 
                        if (listaPrecioBool)
                        {
                            var precioPorActualizar = articulo.Precios.FirstOrDefault(x => x.ListaPrecioId == listaPrecioId && x.FechaActualizacion == articulo.Precios.Where(u => u.ListaPrecioId == listaPrecioId
                                                                     && (u.FechaActualizacion <= fecha)).Max(f => f.FechaActualizacion));

                            var listaPrecioSelect = listaPrecios.FirstOrDefault(x => x.Id == listaPrecioId);

                            var precioCosto = porcentaje
                                ? precioPorActualizar.PrecioCosto + (precioPorActualizar.PrecioCosto * (valor / 100))
                                : precioPorActualizar.PrecioCosto + valor;
                                
                            var precioPublico= precioCosto + (precioCosto * (listaPrecioSelect.PorcentajeGanancia/100));

                            var nuevoPrecio = new Dominio.Entidades.Precio
                            {
                                ArticuloId = articulo.Id,
                                FechaActualizacion= fecha,
                                ListaPrecioId= listaPrecioId,
                                PrecioCosto = precioCosto,
                                PrecioPublico=precioPublico,
                                EstaEliminado=false
                            };

                            _unidadDeTrabajo.PrecioRepositorio.Insertar(nuevoPrecio);

                        }
                        else
                        {
                            foreach (var lista in listaPrecios)
                            {
                                var precioPorActualizar = articulo.Precios.FirstOrDefault(x => x.ListaPrecioId == lista.Id && x.FechaActualizacion == articulo.Precios.Where(u => u.ListaPrecioId == lista.Id
                                                                     && (u.FechaActualizacion <= fecha)).Max(f => f.FechaActualizacion));

                                var listaPrecioSelect = listaPrecios.FirstOrDefault(x => x.Id == lista.Id);

                                var precioCosto = porcentaje
                                    ? precioPorActualizar.PrecioCosto + (precioPorActualizar.PrecioCosto * (valor / 100))
                                    : precioPorActualizar.PrecioCosto + valor;

                                var precioPublico = precioCosto + (precioCosto * (listaPrecioSelect.PorcentajeGanancia / 100));

                                var nuevoPrecio = new Dominio.Entidades.Precio
                                {
                                    ArticuloId = articulo.Id,
                                    FechaActualizacion=fecha,
                                    ListaPrecioId = lista.Id,
                                    PrecioCosto = precioCosto,
                                    PrecioPublico = precioPublico,
                                    EstaEliminado = false
                                };

                                _unidadDeTrabajo.PrecioRepositorio.Insertar(nuevoPrecio);
                            }
                        }
                    }

                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }
    }
}

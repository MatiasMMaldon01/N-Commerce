using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using IServicio.BaseDto;
using IServicios.Articulo.DTOs;
using Servicios.Base;

namespace Servicios.Articulo
{
    public class ArticuloServicio : IArticuloServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.ArticuloRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var dto = (ArticuloCrudDto)dtoEntidad;

                    var entidad = new Dominio.Entidades.Articulo
                    {
                        MarcaId = dto.MarcaId,
                        RubroId = dto.RubroId,
                        UnidadMedidaId = dto.UnidadMedidaId,
                        IvaId = dto.IvaId,
                        Codigo = dto.Codigo,
                        CodigoBarra = dto.CodigoBarra,
                        Abreviatura = dto.Abreviatura,
                        Descripcion = dto.Descripcion,
                        Detalle = dto.Detalle,
                        Ubicacion = dto.Ubicacion,
                        ActivarLimiteVenta = dto.ActivarLimiteVenta,
                        LimiteVenta = dto.LimiteVenta,
                        ActivarHoraVenta = dto.ActivarHoraVenta,
                        HoraLimiteVentaDesde = dto.HoraLimiteVentaDesde,
                        HoraLimiteVentaHasta = dto.HoraLimiteVentaHasta,
                        PermiteStockNegativo = dto.PermiteStockNegativo,
                        DescuentaStock = dto.DescuentaStock,
                        StockMinimo = dto.StockMinimo,
                        Foto = dto.Foto,
                        EstaEliminado = false
                    };


                    _unidadDeTrabajo.ArticuloRepositorio.Insertar(entidad);

                    var listasDePrecios = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado);

                    if (!listasDePrecios.Any())
                        throw new Exception("Por favor cargue las listas de precios");

                    var fecha = DateTime.Now;

                    foreach (var listasDePrecio in listasDePrecios)
                    {
                        var precioArticulo = new Precio
                        {
                            FechaActualizacion = fecha,
                            ListaPrecioId = listasDePrecio.Id,
                            ArticuloId = entidad.Id,
                            PrecioCosto = dto.PrecioCosto,
                            PrecioPublico = dto.PrecioCosto + CalcularGanancia(dto.PrecioCosto, listasDePrecio.PorcentajeGanancia),
                            EstaEliminado = false
                        };

                        _unidadDeTrabajo.PrecioRepositorio.Insertar(precioArticulo);
                    }

                    var configSistema = _unidadDeTrabajo.ConfiguracionRepositorio.Obtener().FirstOrDefault();

                    if (configSistema == null)
                        throw new Exception("Ocurrio un error al Obtener la configuracion del sistema");

                    var depositos = _unidadDeTrabajo.DepositoRepositorio.Obtener();

                    foreach (var deposito in depositos)
                    {
                        _unidadDeTrabajo.StockRepositorio.Insertar(new Stock
                        {
                            DepositoId = deposito.Id,
                            ArticuloId = entidad.Id,
                            Cantidad = deposito.Id==configSistema.DepositoIdStock ?dto.StockActual :0,
                            EstaEliminado = false
                        });
                    }
                    
                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        private decimal CalcularGanancia(decimal monto, decimal porcentaje)
        {
            return (monto * (porcentaje / 100));
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (ArticuloCrudDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Artículo");

            entidad.MarcaId = dto.MarcaId;
            entidad.RubroId = dto.RubroId;
            entidad.UnidadMedidaId = dto.UnidadMedidaId;
            entidad.IvaId = dto.IvaId;
            entidad.Codigo = dto.Codigo;
            entidad.CodigoBarra = dto.CodigoBarra;
            entidad.Abreviatura = dto.Abreviatura;
            entidad.Descripcion = dto.Descripcion;
            entidad.Detalle = dto.Detalle;
            entidad.Ubicacion = dto.Ubicacion;
            entidad.ActivarLimiteVenta = dto.ActivarLimiteVenta;
            entidad.LimiteVenta = dto.LimiteVenta;
            entidad.ActivarHoraVenta = dto.ActivarHoraVenta;
            entidad.HoraLimiteVentaDesde = dto.HoraLimiteVentaDesde;
            entidad.HoraLimiteVentaHasta = dto.HoraLimiteVentaHasta;
            entidad.PermiteStockNegativo = dto.PermiteStockNegativo;
            entidad.DescuentaStock = dto.DescuentaStock;
            entidad.StockMinimo = dto.StockMinimo;
            entidad.Foto = dto.Foto;

            _unidadDeTrabajo.ArticuloRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(id, "Rubro, Marca, UnidadMedida, Iva, Stocks, Stocks.Deposito,Precios, Precios.ListaPrecio");

            return new ArticuloDto
            {
                Id = entidad.Id,
                MarcaId = entidad.MarcaId,
                Marca = entidad.Marca.Descripcion,
                RubroId = entidad.RubroId,
                Rubro = entidad.Rubro.Descripcion,
                UnidadMedidaId = entidad.UnidadMedidaId,
                UnidadMedida = entidad.UnidadMedida.Descripcion,
                IvaId = entidad.IvaId,
                Iva = entidad.Iva.Descripcion,
                Codigo = entidad.Codigo,
                CodigoBarra = entidad.CodigoBarra,
                Abreviatura = entidad.Abreviatura,
                Descripcion = entidad.Descripcion,
                Detalle = entidad.Detalle,
                Ubicacion = entidad.Ubicacion,
                ActivarLimiteVenta = entidad.ActivarLimiteVenta,
                LimiteVenta = entidad.LimiteVenta,
                ActivarHoraVenta = entidad.ActivarHoraVenta,
                HoraLimiteVentaDesde =entidad.HoraLimiteVentaDesde,
                HoraLimiteVentaHasta = entidad.HoraLimiteVentaHasta,
                PermiteStockNegativo = entidad.PermiteStockNegativo,
                DescuentaStock = entidad.DescuentaStock,
                StockMinimo = entidad.StockMinimo,
                Foto = entidad.Foto,
                Eliminado = entidad.EstaEliminado,
                Stocks = entidad.Stocks
                    .Select(x => new StockDepositoDto
                    {
                        Cantidad = x.Cantidad,
                        Deposito = x.Deposito.Descripcion

                    }).ToList(),
                Precios = entidad.Precios.GroupBy(y => y.ListaPrecio).Select(dto => entidad.Precios.FirstOrDefault(p => p.ListaPrecio == dto.Key
                                                                && p.FechaActualizacion == entidad.Precios.Where(u => u.ListaPrecio == dto.Key
                                                                && (u.FechaActualizacion<= DateTime.Now)).Max(f => f.FechaActualizacion)))
                       .Select(list => new PreciosDto
                       {
                           Fecha = list.FechaActualizacion,
                           Precio = list.PrecioPublico,
                           ListaPrecio = list.ListaPrecio.Descripcion

                       }).ToList()
            };

        }


        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {

            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x =>
                 x.Descripcion.Contains(cadenaBuscar)
                 || x.Marca.Descripcion.Contains(cadenaBuscar)
                 || x.Rubro.Descripcion.Contains(cadenaBuscar)
                 || x.UnidadMedida.Descripcion.Contains(cadenaBuscar)
                 || x.Iva.Descripcion.Contains(cadenaBuscar);


            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Rubro, Marca, UnidadMedida, Iva, Stocks, Stocks.Deposito, Precios, Precios.ListaPrecio")

                .Select(x => new ArticuloDto
                {
                    Id = x.Id,
                    MarcaId = x.MarcaId,
                    Marca = x.Marca.Descripcion,
                    RubroId = x.RubroId,
                    Rubro = x.Rubro.Descripcion,
                    UnidadMedidaId = x.UnidadMedidaId,
                    UnidadMedida = x.UnidadMedida.Descripcion,
                    IvaId = x.IvaId,
                    Iva = x.Iva.Descripcion,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Abreviatura = x.Abreviatura,
                    Descripcion = x.Descripcion,
                    Detalle = x.Detalle,
                    Ubicacion = x.Ubicacion,
                    ActivarLimiteVenta = x.ActivarLimiteVenta,
                    LimiteVenta = x.LimiteVenta,
                    ActivarHoraVenta = x.ActivarHoraVenta,
                    HoraLimiteVentaDesde = x.HoraLimiteVentaDesde,
                    HoraLimiteVentaHasta = x.HoraLimiteVentaHasta,
                    PermiteStockNegativo = x.PermiteStockNegativo,
                    DescuentaStock = x.DescuentaStock,
                    StockMinimo = x.StockMinimo,
                    Foto = x.Foto,
                    Eliminado = x.EstaEliminado,
                    Stocks = x.Stocks
                     .Select(s => new StockDepositoDto
                     {
                         Cantidad = s.Cantidad,
                         Deposito = s.Deposito.Descripcion

                     }).ToList(),
                     Precios = x.Precios.GroupBy(y => y.ListaPrecio).Select(dto => x.Precios.FirstOrDefault(p => p.ListaPrecio == dto.Key
                                                                && p.FechaActualizacion == x.Precios.Where(u => u.ListaPrecio == dto.Key
                                                                && (u.FechaActualizacion<=DateTime.Now)).Max(f => f.FechaActualizacion)))
                       .Select(list => new PreciosDto
                       {
                           Fecha = list.FechaActualizacion,
                           Precio = list.PrecioPublico,
                           ListaPrecio = list.ListaPrecio.Descripcion

                       }).ToList()
                })
                     .OrderBy(x => x.Descripcion)
                     .ToList();
        }


        public int ObtenerSiguienteNroCodigo()
        {
            var articulos = _unidadDeTrabajo.ArticuloRepositorio.Obtener();
            return articulos.Any()
            ? articulos.Max(x => x.Codigo) + 1
            : 1;
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.ArticuloRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase)).Any()
                : _unidadDeTrabajo.ArticuloRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase)).Any();

        }

        public ArticuloVentaDto ObtenerAPorCodigo(string codigo, long listaPrecioId, long depositoId)
        {
            var fechaActual = DateTime.Now;
            int.TryParse(codigo, out int codigoArticulo);

            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x => !x.EstaEliminado && (x.CodigoBarra == codigo || x.Codigo == codigoArticulo);

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Stocks, Stocks.Deposito, Precios, Precios.ListaPrecio, Iva, Rubro")
                        .Select(x => new ArticuloVentaDto()
                        {
                            Id = x.Id,
                            Iva = x.Iva.Porcentaje,
                            CodigoBarra = x.CodigoBarra,
                            Descripcion = x.Descripcion,

                            TieneRestriccionHorario = x.Rubro.ActivarHoraVenta ? x.Rubro.ActivarHoraVenta : x.ActivarHoraVenta,
                            HoraDesde= x.Rubro.ActivarHoraVenta ? x.Rubro.HoraLimiteVentaDesde : x.HoraLimiteVentaDesde,
                            HoraHasta = x.Rubro.ActivarHoraVenta ? x.Rubro.HoraLimiteVentaHasta : x.HoraLimiteVentaHasta,

                            TieneRestriccionPorCantidad = x.ActivarLimiteVenta,
                            Limite = x.LimiteVenta,

                            Stock = x.Stocks.Any()
                                    ? x.Stocks.Sum(s => s.Cantidad)
                                    : 0m,
                            Precio = x.Precios.Any()
                                    ? x.Precios.FirstOrDefault(p => p.ListaPrecioId == listaPrecioId && p.FechaActualizacion <= fechaActual && p.FechaActualizacion ==
                                                x.Precios.Where(pre => pre.ListaPrecioId == listaPrecioId && pre.FechaActualizacion <= fechaActual).Max(f => f.FechaActualizacion)).PrecioPublico
                                    : 0m,
                            ListaPrecioId = listaPrecioId
                        }).FirstOrDefault();
        }

        public int ObtenerCantidadArticulos()
        {
            return _unidadDeTrabajo.ArticuloRepositorio.Obtener().Count();
        }

        public IEnumerable<ArticuloVentaDto> ObtenerfLookUp(string cadenaBuscar, long listaPrecioId)
        {
            var fechaActual = DateTime.Now;
            int.TryParse(cadenaBuscar, out int codigoArticulo);

            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x => !x.EstaEliminado && (x.CodigoBarra == cadenaBuscar || x.Descripcion.Contains(cadenaBuscar) || x.Codigo == codigoArticulo);


            var listas = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener();

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Stocks, Stocks.Deposito, Precios, Precios.ListaPrecio, Iva, Rubro")
                        .Select(x => new ArticuloVentaDto()
                        {
                            Id = x.Id,
                            Iva = x.Iva.Porcentaje,
                            CodigoBarra = x.CodigoBarra,
                            Descripcion = x.Descripcion,
                            TieneRestriccionHorario = x.Rubro.ActivarHoraVenta ? x.Rubro.ActivarHoraVenta : x.ActivarHoraVenta,
                            HoraDesde = x.Rubro.ActivarHoraVenta ? x.Rubro.HoraLimiteVentaDesde : x.HoraLimiteVentaDesde,
                            HoraHasta = x.Rubro.ActivarHoraVenta ? x.Rubro.HoraLimiteVentaHasta : x.HoraLimiteVentaHasta,
                            TieneRestriccionPorCantidad = x.ActivarLimiteVenta,
                            Limite = x.LimiteVenta,
                            Stock = x.Stocks.Any()
                                    ? x.Stocks.Sum(s => s.Cantidad)
                                    : 0m,
                            Precio = x.Precios.Any()
                                    ? x.Precios.FirstOrDefault(p => p.ListaPrecioId == listaPrecioId && p.FechaActualizacion <= fechaActual && p.FechaActualizacion ==
                                                x.Precios.Where(pre => pre.ListaPrecioId == listaPrecioId && pre.FechaActualizacion <= fechaActual).Max(f => f.FechaActualizacion)).PrecioPublico
                                    : 0m,
                            ListaPrecioId = listaPrecioId
                        }).ToList();
        }

        public ArticuloCompraDto ObtenerArticuloPorCodigo(string codigo)
        {
            var fechaActual = DateTime.Now;
            int.TryParse(codigo, out int codigoArticulo);

            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x => !x.EstaEliminado && (x.CodigoBarra == codigo || x.Codigo == codigoArticulo);

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Stocks, Stocks.Deposito, Precios, Precios.ListaPrecio, Iva, Rubro")
                        .Select(x => new ArticuloCompraDto()
                        {
                            Id = x.Id,
                            Iva = x.Iva.Porcentaje,
                            CodigoBarra = x.CodigoBarra,
                            Descripcion = x.Descripcion,

                            Stock = x.Stocks.Any()
                                    ? x.Stocks.Sum(s => s.Cantidad)
                                    : 0m,
                            Precio = x.Precios.Any()
                                    ? x.Precios.FirstOrDefault().PrecioPublico
                                    : 0m,
                        }).FirstOrDefault();
        }

    }
}


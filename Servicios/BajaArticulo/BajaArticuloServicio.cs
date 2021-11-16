using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.BajaArticulo;
using IServicios.BajaArticulo.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.BajaArticulo
{
    public class BajaArticuloServicio : IBajaArticuloServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public BajaArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.BajaArticuloRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {

            var dto = (BajaArticuloDto)dtoEntidad;

            var entidad = new Dominio.Entidades.BajaArticulo
            {
                ArticuloId = dto.ArticuloId,
                Cantidad = dto.Cantidad,
                MotivoBajaId = dto.MotivoBajaId,
                Fecha = dto.Fecha,
                Observacion = dto.Observacion,
                EstaEliminado = false
            };

            _unidadDeTrabajo.BajaArticuloRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();

        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (BajaArticuloDto)dtoEntidad;
            var entidad = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(dto.Id);
            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Artículo");

            entidad.ArticuloId = dto.ArticuloId;
            entidad.Cantidad = dto.Cantidad;
            entidad.Fecha = dto.Fecha;
            entidad.MotivoBajaId = dto.MotivoBajaId;
            entidad.Observacion = dto.Observacion;

            _unidadDeTrabajo.BajaArticuloRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
           var entidad= _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(id, "MotivoBaja, Articulo");

            return new BajaArticuloDto
            {
                Id = entidad.Id,
                ArticuloId = entidad.ArticuloId,
                Cantidad = entidad.Cantidad,
                MotivoBajaId=entidad.MotivoBajaId,
                Fecha = entidad.Fecha,
                Observacion = entidad.Observacion
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.BajaArticulo, bool>> filtro = x => true;

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(filtro, "Articulo, MotivoBaja")
                .Select(x => new BajaArticuloDto
                {
                    Id = x.Id,
                    Articulo = x.Articulo.Descripcion,
                    ArticuloId = x.ArticuloId,
                    Cantidad = x.Cantidad,
                    MotivoBaja = x.MotivoBaja.Descripcion,
                    MotivoBajaId = x.MotivoBajaId,
                    Fecha = x.Fecha,
                    Observacion = x.Observacion

                }).OrderByDescending(x => x.Fecha).ToList();                           
        }

        public void ReduccionStock(long articuloId, decimal cantidad, long? depositoId)
        {
            Expression<Func<Dominio.Entidades.Stock, bool>> filtro = x => true;

            if (depositoId.HasValue)
            {
                filtro = filtro.And(x => x.DepositoId == depositoId);
            }

            var stocks = (List<Stock>)_unidadDeTrabajo.StockRepositorio.Obtener(filtro);

            if (stocks == null)
                throw new Exception("Ocurrio un Error al Obtener el Stock");
            
            foreach (var stock in stocks)
            {
                if (stock.ArticuloId == articuloId)
                {
                    if (stock.Cantidad > cantidad)
                    {
                        stock.DepositoId = (long)depositoId;
                        stock.ArticuloId = articuloId;
                        stock.Cantidad = DisminuirStock(stock.Cantidad, cantidad);

                        _unidadDeTrabajo.StockRepositorio.Modificar(stock);
                        _unidadDeTrabajo.Commit();
                    }
                    else
                    {
                        var deposito = _unidadDeTrabajo.DepositoRepositorio.Obtener((long)depositoId);
                        throw new Exception($"En {deposito.Descripcion} no hay Stock suficiente" + Environment.NewLine+ $"El deposito tiene {stock.Cantidad} de este Producto");
                    }                 
                }
            };
        }

        private decimal DisminuirStock(decimal stockActual, decimal disminucionStock)
        {
            var resultado = stockActual - disminucionStock;
            return resultado;
        }
    }
}

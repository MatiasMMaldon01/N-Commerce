using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicio.Deposito;
using IServicio.Deposito.DTOs;
using Servicios.Base;

namespace Servicios.Deposito
{
    public class DepositoServicio : IDepositoSevicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DepositoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.DepositoRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var dto = (DepositoDto)dtoEntidad;

                    var entidad = new Dominio.Entidades.Deposito
                    {
                        Descripcion = dto.Descripcion,
                        Ubicacion = dto.Ubicacion,
                        EstaEliminado = false
                    };
                    _unidadDeTrabajo.DepositoRepositorio.Insertar(entidad);

                    var articulos = _unidadDeTrabajo.ArticuloRepositorio.Obtener();
                    foreach (var articulo in articulos)
                    {
                        _unidadDeTrabajo.StockRepositorio.Insertar(new Stock
                        {
                            ArticuloId = articulo.Id,
                            Cantidad = 0,
                            DepositoId = entidad.Id,
                            EstaEliminado = false
                        });
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

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (DepositoDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.DepositoRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Deposito");

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Deposito");

            entidad.Descripcion = dto.Descripcion;
            entidad.Ubicacion = dto.Ubicacion;

            _unidadDeTrabajo.Commit();

        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.DepositoRepositorio.Obtener(id);

            return new DepositoDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                Ubicacion = entidad.Ubicacion,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos= true)
        {

            Expression<Func<Dominio.Entidades.Deposito, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.DepositoRepositorio.Obtener(filtro)
                .Select(x => new DepositoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Ubicacion = x.Ubicacion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.DepositoRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.DepositoRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}

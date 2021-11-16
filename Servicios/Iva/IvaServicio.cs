using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicio.Iva;
using IServicio.Iva.DTOs;
using Servicios.Base;

namespace Servicios.Iva
{
    public class IvaServicio : IIvaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public IvaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.IvaRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (IvaDto)dtoEntidad;

            var entidad = new Dominio.Entidades.Iva
            {
                Descripcion = dto.Descripcion,
                Porcentaje = dto.Porcentaje,
                EstaEliminado = false
            };

            _unidadDeTrabajo.IvaRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (IvaDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.IvaRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Iva");

            entidad.Descripcion = dto.Descripcion;
            entidad.Porcentaje = dto.Porcentaje;

            _unidadDeTrabajo.IvaRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.IvaRepositorio.Obtener(id);

            return new IvaDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                Porcentaje = entidad.Porcentaje,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos= true)
        {

            Expression<Func<Dominio.Entidades.Iva, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }
            return _unidadDeTrabajo.IvaRepositorio.Obtener(filtro)
                .Select(x => new IvaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Porcentaje = x.Porcentaje,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.IvaRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.IvaRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}

using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.MotivoBaja;
using IServicios.MotivoBaja.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.MotivoBaja
{
    public class MotivoBajaServicio: IMotivoBajaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public MotivoBajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void Eliminar(long id)
        {
            _unidadDeTrabajo.MotivoBajaRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (MotivoBajaDto)dtoEntidad;

            var entidad = new Dominio.Entidades.MotivoBaja
            {
                Descripcion = dto.Descripcion,
                EstaEliminado = false
            };

            _unidadDeTrabajo.MotivoBajaRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (MotivoBajaDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Provincia");

            entidad.Descripcion = dto.Descripcion;

            _unidadDeTrabajo.MotivoBajaRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(id);

            return new MotivoBajaDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {

            Expression<Func<Dominio.Entidades.MotivoBaja, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(filtro)
                .Select(x => new MotivoBajaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(x => !x.EstaEliminado
                                                                     && x.Id != entidadId.Value
                                                                     && x.Descripcion.Equals(datoVerificar,
                                                                         StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(x => !x.EstaEliminado
                                                                     && x.Descripcion.Equals(datoVerificar,
                                                                         StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}

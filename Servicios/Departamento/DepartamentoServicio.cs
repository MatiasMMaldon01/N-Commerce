using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicio.Departamento;
using IServicio.Departamento.DTOs;
using IServicios.Departamento.DTOs;
using Servicios.Base;

namespace Servicios.Departamento
{
    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DepartamentoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.DepartamentoRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (DepartamentoCrudDto)dtoEntidad;

            var entidad = new Dominio.Entidades.Departamento
            {
                Descripcion = dto.Descripcion,
                ProvinciaId = dto.ProvinciaId,
                EstaEliminado = false
            };

            _unidadDeTrabajo.DepartamentoRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (DepartamentoCrudDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.DepartamentoRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Departamento");

            entidad.Descripcion = dto.Descripcion;
            entidad.ProvinciaId = dto.ProvinciaId;

            _unidadDeTrabajo.DepartamentoRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.DepartamentoRepositorio.Obtener(id, "Provincia");

            return new DepartamentoDto
            {
                Id = entidad.Id,

                Descripcion = entidad.Descripcion,

                Provincia = entidad.Provincia.Descripcion,
                ProvinciaId = entidad.ProvinciaId,

                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos=true)
        {
            Expression<Func<Dominio.Entidades.Departamento, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar) || x.Provincia.Descripcion.Contains(cadenaBuscar);
            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }
            return _unidadDeTrabajo.DepartamentoRepositorio.Obtener(filtro,"Provincia")                   
                .Select(x => new DepartamentoDto
                {
                    Id = x.Id,
                    Provincia = x.Provincia.Descripcion,
                    ProvinciaId = x.ProvinciaId,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public IEnumerable<DepartamentoDto> ObtenerPorProvincia(long provinciaId)
        {
            return _unidadDeTrabajo.DepartamentoRepositorio.Obtener(x => x.ProvinciaId == provinciaId, "Provincia")
                .Select(x => new DepartamentoDto
                {
                    Id = x.Id,
                    Provincia = x.Provincia.Descripcion,
                    ProvinciaId = x.ProvinciaId,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long idRelacional, long? entidadId = null)
        {

            return entidadId.HasValue
                ? _unidadDeTrabajo.DepartamentoRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.ProvinciaId == idRelacional
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.DepartamentoRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.ProvinciaId == idRelacional
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}

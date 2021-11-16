using IServicio.BaseDto;
using IServicio.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.Localidad.DTOs;
using System.Linq.Expressions;
using Servicios.Base;

namespace Servicios.Localidad
{
    public class LocalidadServicio : ILocalidadServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public LocalidadServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.LocalidadRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (LocalidadDto) dtoEntidad;

            var entidad = new Dominio.Entidades.Localidad
            {
                Descripcion = dto.Descripcion,
                DepartamentoId = dto.DepartamentoId,
                EstaEliminado = false
            };

            _unidadDeTrabajo.LocalidadRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (LocalidadDto) dtoEntidad;

            var entidad = _unidadDeTrabajo.LocalidadRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la Localidad");

            entidad.Descripcion = dto.Descripcion;
            entidad.DepartamentoId = dto.DepartamentoId;

            _unidadDeTrabajo.LocalidadRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.LocalidadRepositorio.Obtener(id, "Departamento, Departamento.Provincia");

            return new LocalidadDto
            {
                Id = entidad.Id,

                Descripcion = entidad.Descripcion,

                DepartamentoId = entidad.DepartamentoId,
                Departamento = entidad.Departamento.Descripcion,

                Provincia = entidad.Departamento.Provincia.Descripcion,
                ProvinciaId = entidad.Departamento.ProvinciaId,

                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos=true)
        {
            Expression<Func<Dominio.Entidades.Localidad, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar)
                    || x.Departamento.Descripcion.Contains(cadenaBuscar)
                    || x.Departamento.Provincia.Descripcion.Contains(cadenaBuscar);
            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }
            return _unidadDeTrabajo.LocalidadRepositorio.Obtener(filtro, "Departamento, Departamento.Provincia")
                .Select(x => new LocalidadDto
                {
                    Id = x.Id,
                    DepartamentoId = x.DepartamentoId,
                    Departamento = x.Departamento.Descripcion,
                    Provincia = x.Departamento.Provincia.Descripcion,
                    ProvinciaId = x.Departamento.ProvinciaId,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public IEnumerable<LocalidadDto> ObtenerPorDepartamento(long departamentoId)
        {
            return _unidadDeTrabajo.LocalidadRepositorio.Obtener(x => x.DepartamentoId == departamentoId, "Departamento, Departamento.Provincia")
                .Select(x => new LocalidadDto
                {
                    Id = x.Id,
                    DepartamentoId = x.DepartamentoId,
                    Departamento = x.Departamento.Descripcion,
                    Provincia = x.Departamento.Provincia.Descripcion,
                    ProvinciaId = x.Departamento.ProvinciaId,
                    Descripcion = x.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long idRelacional, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.LocalidadRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.DepartamentoId == idRelacional
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.LocalidadRepositorio.Obtener(x => !x.EstaEliminado
                                                                     && x.DepartamentoId == idRelacional
                                                                     && x.Descripcion.Equals(datoVerificar,
                                                                         StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }
    }
}

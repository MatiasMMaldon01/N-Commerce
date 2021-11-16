using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.UnidadDeTrabajo;
using IServicio.Persona.DTOs;
using Servicios.Base;

namespace Servicios.Persona
{
    public class Empleado : Persona
    {
        public Empleado()
            : base()
        {
        }
        
        public override long Insertar(PersonaDto entidad)
        {
            if(entidad == null)
                throw new Exception("Ocurrio un error al Insertar el Empleado");

            var entidadNueva = (EmpleadoDto)entidad;

            var entidadId = _unidadDeTrabajo.EmpleadoRepositorio.Insertar(new Dominio.Entidades.Empleado
            {
                EstaEliminado = false,
                Legajo = entidadNueva.Legajo,
                Apellido = entidadNueva.Apellido,
                Nombre = entidadNueva.Nombre,
                Dni = entidadNueva.Dni,
                Direccion = entidadNueva.Direccion,
                LocalidadId = entidadNueva.LocalidadId,
                Mail = entidadNueva.Mail,
                Telefono = entidadNueva.Telefono,
                Foto = entidadNueva.Foto,
            });

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public override void Modificar(PersonaDto entidad)
        {
            if (entidad == null)
                throw new Exception("Ocurrio un error al modificar el Empleado");

            var entidadModificar = (EmpleadoDto)entidad;

            _unidadDeTrabajo.EmpleadoRepositorio.Modificar(new Dominio.Entidades.Empleado
            {
                Id = entidadModificar.Id,
                EstaEliminado = false,
                Legajo = entidadModificar.Legajo,
                Apellido = entidadModificar.Apellido,
                Direccion = entidadModificar.Direccion,
                Dni = entidadModificar.Dni,
                Mail = entidadModificar.Mail,
                Foto = entidadModificar.Foto,
                LocalidadId = entidadModificar.LocalidadId,
                Nombre = entidadModificar.Nombre,
                Telefono = entidadModificar.Telefono,
            });

            _unidadDeTrabajo.Commit();
        }

        public override void Eliminar(long id)
        {
            _unidadDeTrabajo.EmpleadoRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<PersonaDto> Obtener(string cadenaBuscar, bool mostrarTodos)
        {
            Expression<Func<Dominio.Entidades.Empleado, bool>> filtro = empleado =>
                empleado.Apellido.Contains(cadenaBuscar)
                || empleado.Nombre.Contains(cadenaBuscar)
                || empleado.Dni == cadenaBuscar;

            if (!mostrarTodos)
            {
                filtro = filtro.And(x=>!x.EstaEliminado);
            }

            return _unidadDeTrabajo.EmpleadoRepositorio.Obtener(filtro, "Localidad, Localidad.Departamento, Localidad.Departamento.Provincia")
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Direccion = x.Direccion,
                        Dni = x.Dni,
                        Mail = x.Mail,
                        Foto = x.Foto,
                        LocalidadId = x.LocalidadId,
                        Localidad = x.Localidad.Descripcion,
                        DepartamentoId = x.Localidad.DepartamentoId,
                        Departamento = x.Localidad.Departamento.Descripcion,
                        ProvinciaId = x.Localidad.Departamento.ProvinciaId,
                        Provincia = x.Localidad.Departamento.Provincia.Descripcion,
                        Nombre = x.Nombre,
                        Telefono = x.Telefono,
                        Eliminado = x.EstaEliminado,

                    }).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList();
        }

        public override PersonaDto Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.EmpleadoRepositorio.Obtener(id, "Localidad, Localidad.Departamento, Localidad.Departamento.Provincia");

            return new EmpleadoDto
            {
                Id = entidad.Id,
                Legajo = entidad.Legajo,
                Apellido = entidad.Apellido,
                Direccion = entidad.Direccion,
                Dni = entidad.Dni,
                Mail = entidad.Mail,
                Foto = entidad.Foto,
                LocalidadId = entidad.LocalidadId,
                Localidad = entidad.Localidad.Descripcion,
                DepartamentoId = entidad.Localidad.DepartamentoId,
                Departamento = entidad.Localidad.Departamento.Descripcion,
                ProvinciaId = entidad.Localidad.Departamento.ProvinciaId,
                Provincia = entidad.Localidad.Departamento.Provincia.Descripcion,
                Nombre = entidad.Nombre,
                Telefono = entidad.Telefono,
                Eliminado = entidad.EstaEliminado,
            };
        }
    }
}

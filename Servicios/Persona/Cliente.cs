using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.UnidadDeTrabajo;
using IServicio.Persona.DTOs;
using Servicios.Base;

namespace Servicios.Persona
{
    public class Cliente : Persona
    {
        public override long Insertar(PersonaDto entidad)
        {
            if (entidad == null)
                throw new Exception("Ocurrio un error al Insertar el Cliente");

            var entidadNueva = (ClienteDto)entidad;

            var entidadId = _unidadDeTrabajo.ClienteRepositorio.Insertar(new Dominio.Entidades.Cliente
            {
                EstaEliminado = false,
                Apellido = entidadNueva.Apellido,
                Nombre = entidadNueva.Nombre,
                Dni = entidadNueva.Dni,
                Direccion = entidadNueva.Direccion,
                LocalidadId = entidadNueva.LocalidadId,
                Mail = entidadNueva.Mail,
                Telefono = entidadNueva.Telefono,
                CondicionIvaId = entidadNueva.CondicionIvaId,
                ActivarCtaCte = entidadNueva.ActivarCtaCte,
                MontoMaximoCtaCte = entidadNueva.MontoMaximoCtaCte,
                TieneLimiteCompra = entidadNueva.TieneLimiteCompra
            });

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public override void Modificar(PersonaDto entidad)
        {
            if (entidad == null)
                throw new Exception("Ocurrio un error al modificar el Cliente");

            var entidadModificar = (ClienteDto)entidad;

            _unidadDeTrabajo.ClienteRepositorio.Modificar(new Dominio.Entidades.Cliente
            {
                Id = entidadModificar.Id,
                EstaEliminado = false,
                Apellido = entidadModificar.Apellido,
                Direccion = entidadModificar.Direccion,
                Dni = entidadModificar.Dni,
                Mail = entidadModificar.Mail,
                LocalidadId = entidadModificar.LocalidadId,
                Nombre = entidadModificar.Nombre,
                Telefono = entidadModificar.Telefono,
                CondicionIvaId = entidadModificar.CondicionIvaId,
                ActivarCtaCte = entidadModificar.ActivarCtaCte,
                MontoMaximoCtaCte = entidadModificar.MontoMaximoCtaCte,
                TieneLimiteCompra = entidadModificar.TieneLimiteCompra
            });

            _unidadDeTrabajo.Commit();
        }

        public override void Eliminar(long id)
        {
            _unidadDeTrabajo.ClienteRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<PersonaDto> Obtener(string cadenaBuscar, bool mostrarTodos)
        {
            Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = cliente => cliente.Dni != "99999999"
                &&  (cliente.Apellido.Contains(cadenaBuscar)
                    || cliente.Nombre.Contains(cadenaBuscar)
                    || cliente.Dni == cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x=> !x.EstaEliminado);
            }

            return _unidadDeTrabajo.ClienteRepositorio.Obtener(filtro, "CondicionIva, Localidad, " + "Localidad.Departamento, Localidad.Departamento.Provincia")
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Direccion = x.Direccion,
                        Dni = x.Dni,
                        Mail = x.Mail,
                        ActivarCtaCte = x.ActivarCtaCte,
                        TieneLimiteCompra = x.TieneLimiteCompra,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        CondicionIvaId = x.CondicionIvaId,
                        CondicionIva = x.CondicionIva.Descripcion,
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
            var entidad = _unidadDeTrabajo.ClienteRepositorio.Obtener(id, "CondicionIva, Localidad, " +
                                                                          "Localidad.Departamento, Localidad.Departamento.Provincia");

            return new ClienteDto
            {
                Id = entidad.Id,
                Apellido = entidad.Apellido,
                Direccion = entidad.Direccion,
                Dni = entidad.Dni,
                Mail = entidad.Mail,
                ActivarCtaCte = entidad.ActivarCtaCte,
                TieneLimiteCompra = entidad.TieneLimiteCompra,
                MontoMaximoCtaCte = entidad.MontoMaximoCtaCte,
                CondicionIvaId = entidad.CondicionIvaId,
                CondicionIva = entidad.CondicionIva.Descripcion,
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

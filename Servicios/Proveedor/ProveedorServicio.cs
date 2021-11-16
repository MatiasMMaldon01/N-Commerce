using Dominio.UnidadDeTrabajo;
using IServicio.BaseDto;
using IServicios.Proveedores;
using IServicios.Proveedores.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.Proveedores
{
    public class ProveedoresServicio : IProveedoresServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public ProveedoresServicio( IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;   
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.ProveedorRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var dto = (ProveedoresDto)dtoEntidad;

            var entidad = new Dominio.Entidades.Proveedor
            {
                RazonSocial = dto.RazonSocial,
                CUIT= dto.CUIL,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                LocalidadId = dto.LocalidadId,
                CondicionIvaId = dto.CondicionIvaId,
                Mail = dto.Mail,
            };

            _unidadDeTrabajo.ProveedorRepositorio.Insertar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (ProveedoresDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.ProveedorRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Proveedor");

            entidad.RazonSocial= dto.RazonSocial;
            entidad.CUIT= dto.CUIL;
            entidad.Telefono= dto.Telefono;
            entidad.Direccion= dto.Direccion;
            entidad.LocalidadId= dto.LocalidadId;
            entidad.CondicionIvaId= dto.CondicionIvaId;
            entidad.Mail = dto.Mail;

            _unidadDeTrabajo.ProveedorRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {

            var entidad = _unidadDeTrabajo.ProveedorRepositorio.Obtener(id);

            return new ProveedoresDto
            {
                Id = entidad.Id,
                RazonSocial = entidad.RazonSocial,
                CUIL = entidad.CUIT,
                Telefono = entidad.Telefono,
                Direccion = entidad.Direccion,
                LocalidadId = entidad.LocalidadId,
                Localidad = entidad.Localidad.Descripcion,
                CondicionIvaId = entidad.CondicionIvaId,
                CondicionIva = entidad.CondicionIva.Descripcion,
                Mail = entidad.Mail,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Proveedor, bool>> filtro = x => x.RazonSocial.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.ProveedorRepositorio.Obtener(filtro, "CondicionIva , Localidad")
                .Select(x => new ProveedoresDto
                {
                    Id = x.Id,
                    RazonSocial = x.RazonSocial,
                    CUIL = x.CUIT,
                    Telefono = x.Telefono,
                    Direccion= x.Direccion,
                    Mail = x.Mail,
                    LocalidadId = x.LocalidadId,
                    Localidad = x.Localidad.Descripcion,
                    CondicionIvaId = x.CondicionIvaId,
                    CondicionIva = x.CondicionIva.Descripcion,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.RazonSocial)
                .ToList();
        }
    }
}

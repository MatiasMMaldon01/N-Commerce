using System;
using IServicio.BaseDto;
using IServicio.Usuario;
using System.Collections.Generic;
using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.Usuario.DTOs;
using static Aplicacion.Constantes.Clases.Password;
using System.Linq.Expressions;

namespace Servicios.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Bloquear(long usuarioId)
        {
            var usuario = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuarioId);

            if(usuario == null) 
                throw new Exception("Ocurrio un error al obtener el Usuario.");

            usuario.EstaBloqueado = !usuario.EstaBloqueado;

            _unidadDeTrabajo.UsuarioRepositorio.Modificar(usuario);
            _unidadDeTrabajo.Commit();
        }

        public void Crear(long empleadoId, string apellidoEmpleado, string nombreEmpleado)
        {
            var nuevoUsuario = new Dominio.Entidades.Usuario
            {
                EstaEliminado = false,
                EmpleadoId = empleadoId,
                EstaBloqueado = false,
                Nombre = ObtenerNombreUsuario(apellidoEmpleado, nombreEmpleado),
                Password = Encriptar(PasswordPorDefecto)
            };

            _unidadDeTrabajo.UsuarioRepositorio.Insertar(nuevoUsuario);
            _unidadDeTrabajo.Commit();
        }

        public void ResetPassword(long usuarioId)
        {
            var usuario = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuarioId);

            usuario.Password = Encriptar(PasswordPorDefecto);

            _unidadDeTrabajo.UsuarioRepositorio.Modificar(usuario);

            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var usuario = _unidadDeTrabajo.UsuarioRepositorio.Obtener(id, "Empleado");

            return new UsuarioDto
            {
                Eliminado = usuario.EstaEliminado,
                Id = usuario.Id,
                EstaBloqueado = usuario.EstaBloqueado,
                ApellidoEmpleado = usuario.Empleado.Apellido,
                NombreEmpleado = usuario.Empleado.Nombre,
                Password = usuario.Password,
                EmpleadoId = usuario.EmpleadoId,
                NombreUsuario = usuario.Nombre
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos=true)
        {
            Expression<Func<Dominio.Entidades.Empleado, bool>> filtro = x => !x.EstaEliminado;

            var empleados = _unidadDeTrabajo.EmpleadoRepositorio.Obtener(filtro, "Usuarios");

            var listaUsuario = empleados.Select(emple => new UsuarioDto
            {
                EmpleadoId = emple.Id,
                ApellidoEmpleado = emple.Apellido,
                NombreEmpleado = emple.Nombre,
                Id = emple.Usuarios.Any()
                    ? emple.Usuarios.FirstOrDefault().Id
                    : 0,
                NombreUsuario = emple.Usuarios.Any()
                    ? emple.Usuarios.FirstOrDefault()?.Nombre
                    : "NO ASIGNADO",
                EstaBloqueado = emple.Usuarios.Any()
                    ? emple.Usuarios.FirstOrDefault().EstaBloqueado
                    : false,
                Eliminado = emple.Usuarios.Any()
                    ? emple.Usuarios.FirstOrDefault().EstaEliminado
                    : false,
            }).ToList();

            return listaUsuario.ToList();
        }
      
        // ===================================================================================================== //
        // ============================       Metodos Privados       =========================================== //
        // ===================================================================================================== //

        private string ObtenerNombreUsuario(string apellidoEmpleado, string nombreEmpleado)
        {
            if (string.IsNullOrEmpty(apellidoEmpleado))
                throw new Exception("El apellido del Empleado no puede ser null");

            if (string.IsNullOrEmpty(nombreEmpleado))
                throw new Exception("El nombre del empleado no puede ser null");

            int contadorLetras = 1;

            var listaUsuarios = _unidadDeTrabajo.UsuarioRepositorio.Obtener();

            var nombreUsuario =
                $"{nombreEmpleado.ToLower().Trim().Substring(0, contadorLetras)}" +
                $"{apellidoEmpleado.ToLower().Trim().Replace(' ', new char())}";

            while (listaUsuarios.Any(x=>x.Nombre == nombreUsuario))
            {
                contadorLetras++;
                nombreUsuario =
                    $"{nombreEmpleado.ToLower().Trim().Substring(0, contadorLetras)}" +
                    $"{apellidoEmpleado.ToLower().Trim().Replace(' ', new char())}";
            }

            return nombreUsuario;
        }
    }
}

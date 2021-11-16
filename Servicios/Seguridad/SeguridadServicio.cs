using System;
using System.Linq;
using Aplicacion.Constantes;
using Dominio.UnidadDeTrabajo;
using IServicio.Seguridad;
using IServicio.Usuario.DTOs;
using static Aplicacion.Constantes.Clases.Password;

namespace Servicios.Seguridad
{
    public class SeguridadServicio : ISeguridadServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public SeguridadServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public UsuarioDto ObtenerUsuarioLogin(string nombreUsuario)
        {
            var usuario = _unidadDeTrabajo.UsuarioRepositorio.Obtener(x=>x.Nombre == nombreUsuario, "Empleado").FirstOrDefault();

            if(usuario == null) 
                throw new Exception("El usuario no existe");

            return new UsuarioDto
            {
                Eliminado = usuario.EstaBloqueado,
                EstaBloqueado = usuario.EstaBloqueado,
                ApellidoEmpleado = usuario.Empleado.Apellido,
                EmpleadoId = usuario.EmpleadoId,
                NombreEmpleado = usuario.Empleado.Nombre,
                NombreUsuario = usuario.Nombre,
                Id = usuario.Id,
                Password = usuario.Password,
                FotoEmpleado = usuario.Empleado.Foto
            };
        }

        public bool VerificarAcceso(string usuario, string password)
        {
            var pass = Encriptar(password);

            return _unidadDeTrabajo.UsuarioRepositorio.Obtener(x => x.Nombre == usuario && x.Password == pass && x.EstaBloqueado==false).Any();
        }
    }
}

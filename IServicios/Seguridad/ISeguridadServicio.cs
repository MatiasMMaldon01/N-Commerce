using IServicio.Usuario.DTOs;

namespace IServicio.Seguridad
{
    public interface ISeguridadServicio
    {
        bool VerificarAcceso(string usuario, string password);

        UsuarioDto ObtenerUsuarioLogin(string nombreUsuario);
    }
}

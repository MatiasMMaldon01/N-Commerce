using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio;

namespace Infraestructura.UnidadDeTrabajo
{
    public partial class UnidadDeTrabajo
    {
        // ============================================================================================================ //

        private IRepositorio<Usuario> usuarioRepositorio;
        public IRepositorio<Usuario> UsuarioRepositorio => usuarioRepositorio
                                                           ?? (usuarioRepositorio =
                                                               new Repositorio<Usuario>(_context));

        // ============================================================================================================ //
    }
}

using IServicio.BaseDto;

namespace IServicio.Usuario.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public long EmpleadoId { get; set; }

        public string ApellidoEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public string ApyNomEmpleado => $"{ApellidoEmpleado}, {NombreEmpleado}";

        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public string EstaBloqueadoStr => EstaBloqueado ? "SI" : "NO";

        public byte[] FotoEmpleado { get; set; }
    }
}

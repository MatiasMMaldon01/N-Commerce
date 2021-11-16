namespace IServicio.Persona.DTOs
{
    public class EmpleadoDto : PersonaDto
    {
        public int Legajo { get; set; }

        public byte[] Foto { get; set; }
    }
}

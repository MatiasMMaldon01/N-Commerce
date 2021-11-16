using IServicio.BaseDto;

namespace IServicio.Persona.DTOs
{
    public class PersonaDto : DtoBase
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public long LocalidadId { get; set; }

        public string Localidad { get; set; }

        public long DepartamentoId { get; set; }

        public string Departamento { get; set; }

        public long ProvinciaId { get; set; }

        public string Provincia { get; set; }
    }
}

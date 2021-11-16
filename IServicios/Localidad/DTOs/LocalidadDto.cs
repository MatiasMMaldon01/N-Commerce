using IServicio.BaseDto;

namespace IServicio.Localidad.DTOs
{
    public class LocalidadDto : DtoBase
    {
        public long ProvinciaId { get; set; }
        public string Provincia { get; set; }

        public long DepartamentoId { get; set; }
        public string Departamento { get; set; }

        public string Descripcion { get; set; }
    }
}

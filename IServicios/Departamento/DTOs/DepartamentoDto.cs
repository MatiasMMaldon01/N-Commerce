using IServicio.BaseDto;

namespace IServicio.Departamento.DTOs
{
    public class DepartamentoDto : DtoBase
    {
        public long ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string Descripcion { get; set; }
    }
}

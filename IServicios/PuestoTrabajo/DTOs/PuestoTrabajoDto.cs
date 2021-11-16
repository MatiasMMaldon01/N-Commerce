using IServicio.BaseDto;

namespace IServicios.PuestoTrabajo.DTOs
{
    public class PuestoTrabajoDto : DtoBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}

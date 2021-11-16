using IServicio.BaseDto;

namespace IServicio.Deposito.DTOs
{
    public class DepositoDto : DtoBase
    {
        public string Descripcion { get; set; }

        public string Ubicacion { get; set; }
    }
}

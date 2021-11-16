using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IFormaPagoCtaCte : IFormaPago
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ClienteId { get; set; }
    }
}

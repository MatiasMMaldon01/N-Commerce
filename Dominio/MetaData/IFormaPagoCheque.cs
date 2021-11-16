using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IFormaPagoCheque : IFormaPago
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ChequeId { get; set; }
    }
}

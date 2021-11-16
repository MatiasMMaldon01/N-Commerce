using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface INotaCredito : IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligaotrio")]
        long ComprobanteId { get; set; }
    }
}

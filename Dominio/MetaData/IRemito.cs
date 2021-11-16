using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IRemito : IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ClienteId { get; set; }
    }
}

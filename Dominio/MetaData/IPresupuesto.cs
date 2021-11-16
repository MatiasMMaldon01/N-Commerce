using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IPresupuesto : IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ClienteId { get; set; }
    }
}

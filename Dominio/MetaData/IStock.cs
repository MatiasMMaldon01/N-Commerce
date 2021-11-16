using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IStock
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ArticuloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long DepositoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(0)]
        decimal Cantidad { get; set; }
    }
}

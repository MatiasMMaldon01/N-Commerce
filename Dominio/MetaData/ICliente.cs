using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface ICliente : IPersona
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long CondicionIvaId { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool ActivarCtaCte { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool TieneLimiteCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(0)]
        [DataType(DataType.Currency)]
        decimal MontoMaximoCtaCte { get; set; }
    }
}

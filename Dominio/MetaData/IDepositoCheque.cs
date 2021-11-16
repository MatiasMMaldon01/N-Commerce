using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IDepositoCheque
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ChequeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CuentaBancariaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime Fecha { get; set; }
    }
}

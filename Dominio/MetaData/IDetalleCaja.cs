using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface IDetalleCaja
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CajaId { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoPago TipoPago { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }
    }
}

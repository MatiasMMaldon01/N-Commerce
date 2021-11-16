using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IFormaPagoTarjeta : IFormaPago
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long TarjetaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string CuponPago { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        int CantidadCuotas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface ICuentaBancaria
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long BancoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Titular { get; set; }
    }
}

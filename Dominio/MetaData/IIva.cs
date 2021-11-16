using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IIva
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor {1} caracteres.")]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        decimal Porcentaje { get; set; }
    }
}

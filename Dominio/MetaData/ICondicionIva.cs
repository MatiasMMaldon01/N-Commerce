using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface ICondicionIva
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Condición de Iva")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Descripcion_CondicionIva", IsUnique = true)]
        string Descripcion { get; set; }

    }
}

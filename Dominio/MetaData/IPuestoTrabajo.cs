using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface IPuestoTrabajo
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        int Codigo { get; set; }

        [Display(Name = @"Descripción")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Descripcion_PuestoTrabajo", IsUnique = true)]
        string Descripcion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface IProvincia
    {
        // Configuración de Mapeo

        [Display(Name = @"Descripción")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Descripcion_Provincia", IsUnique = true)]
        string Descripcion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface IDepartamento
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Provincia")]
        [Index("Index_ProvinciaId_Descripcion_Departamento", IsUnique = true, Order = 1)]
        long ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Localidad")]
        [Index("Index_ProvinciaId_Descripcion_Departamento", IsUnique = true, Order = 2)]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }
    }
}

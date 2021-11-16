using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface ILocalidad
    {
        [Required(ErrorMessage ="El campo {0} es Obligatorio.")]
        [Display(Name = "Provincia")]
        [Index("Index_DepartamentoId_Descripcion_Localidad", IsUnique = true, Order = 1)]
        long DepartamentoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Localidad")]
        [Index("Index_DepartamentoId_Descripcion_Localidad", IsUnique = true, Order = 2)]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }
    }
}

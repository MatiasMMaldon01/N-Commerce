using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.MetaData
{
    public interface IDeposito
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Display(Name = "Nombre Deposito")]
        [Index("Index_Descripcion_Deposito", IsUnique = true)]
        string Descripcion { get; set; }

        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Ubicacion { get; set; }
    }
}

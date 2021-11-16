using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IConceptoGasto
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }
    }
}

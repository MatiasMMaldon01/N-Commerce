using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IListaPrecio
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal PorcentajeGanancia { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(false)]
        bool NecesitaAutorizacion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IEmpleado : IPersona
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Legajo")]
        int Legajo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Foto")]
        byte[] Foto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IUsuario
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Empleado")]
        long EmpleadoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Nombre Usuario")]
        [StringLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Contraseña")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [DataType(DataType.Password)]
        string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Apellido")]
        bool EstaBloqueado { get; set; }
    }
}

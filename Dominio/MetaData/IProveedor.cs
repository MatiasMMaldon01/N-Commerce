using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IProveedor
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Razon Social")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string RazonSocial { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "CUIT")]
        [StringLength(15, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string CUIT { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Dirección")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "E-Mail")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} no tiene el formato correcto")]
        string Mail { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Localidad")]
        long LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Proveedor")]
        long CondicionIvaId { get; set; }
    }
}

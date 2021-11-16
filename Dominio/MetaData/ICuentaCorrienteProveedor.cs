using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface ICuentaCorrienteProveedor : IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        Estado Estado { get; set; }
    }
}

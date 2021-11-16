using System;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface IMovimientoCuentaCorrienteProveedor : IMovimiento
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ProveedorId { get; set; }

    }
}

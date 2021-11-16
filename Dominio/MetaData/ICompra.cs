using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface ICompra
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ProveedorId { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime FechaEntrega { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal Iva27 { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal PrecepcionTemp { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal PrecepcionPyP { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal PrecepcionIva { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal PrecepcionIB { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        Estado EstadoFactura { get; set; }
    }
}

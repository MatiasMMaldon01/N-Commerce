using System;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long EmpleadoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.DateTime)]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        int Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal SubTotal { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Descuento { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Total { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Iva21 { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Iva105 { get; set; }

        TipoComprobante TipoComprobante { get; set; }
    }
}

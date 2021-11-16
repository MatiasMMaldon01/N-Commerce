using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface ICaja
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long UsuarioAperturaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal MontoInicial { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        DateTime FechaApertura { get; set; }


        // ===================================================== //
        // ============      Cierre de Caja      =============== //
        // ===================================================== //


        long? UsuarioCierreId { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? FechaCierre { get; set; }
        
        [DataType(DataType.Currency)]
        decimal? MontoCierre { get; set; }


        // ===================================================== //


        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalEntradaEfectivo { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalSalidaEfectivo { get; set; }

        // ===================================================== //

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalEntradaTarjeta { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalSalidaTarjeta { get; set; }

        // ===================================================== //

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalEntradaCheque { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalSalidaCheque { get; set; }

        // ===================================================== //

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalEntradaCtaCte { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DefaultValue(0)]
        decimal TotalSalidaCtaCte { get; set; }

    }
}

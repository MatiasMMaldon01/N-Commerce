using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IRubro
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor {1} caracteres.")]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool ActivarHoraVenta { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? HoraLimiteVentaDesde { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? HoraLimiteVentaHasta { get; set; }
    }
}

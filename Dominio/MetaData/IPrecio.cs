using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IPrecio
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ListaPrecioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ArticuloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Currency)]
        decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Currency)]
        decimal PrecioPublico { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.DateTime)]
        DateTime FechaActualizacion { get; set; }
    }
}

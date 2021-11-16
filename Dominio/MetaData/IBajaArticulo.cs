using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IBajaArticulo
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ArticuloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long MotivoBajaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        decimal Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Date)]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor {1} caracteres.")]
        string Observacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        byte[] Foto { get; set; }
    }
}

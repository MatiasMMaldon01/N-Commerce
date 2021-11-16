using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.MetaData
{
    public interface IArticulo
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long MarcaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long RubroId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long UnidadMedidaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long IvaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        int Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string CodigoBarra { get; set; }

        [StringLength(10, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Abreviatura { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Detalle { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Ubicacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        byte[] Foto { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool ActivarLimiteVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Currency)]
        decimal LimiteVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool ActivarHoraVenta { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? HoraLimiteVentaDesde { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? HoraLimiteVentaHasta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(true)]
        bool PermiteStockNegativo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(true)]
        bool DescuentaStock { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        decimal StockMinimo { get; set; }
    }
}

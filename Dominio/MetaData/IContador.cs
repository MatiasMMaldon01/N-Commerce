using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Constantes;

namespace Dominio.MetaData
{
    public interface IContador
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [EnumDataType(typeof(TipoComprobante))]
        TipoComprobante TipoComprobante { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(0)]
        int Valor { get; set; }
    }
}

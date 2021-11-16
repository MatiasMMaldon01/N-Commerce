using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Contador")]
    [MetadataType(typeof(IContador))]
    public class Contador : EntidadBase
    {
        public TipoComprobante TipoComprobante { get; set; }

        public int Valor { get; set; }
    }
}

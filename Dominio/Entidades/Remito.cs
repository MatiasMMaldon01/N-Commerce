using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_Remito")]
    [MetadataType(typeof(IRemito))]
    public class Remito : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}

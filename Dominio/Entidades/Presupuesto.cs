using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_Presupuesto")]
    [MetadataType(typeof(IPresupuesto))]
    public class Presupuesto : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }


        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}

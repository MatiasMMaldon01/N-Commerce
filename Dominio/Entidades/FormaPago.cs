using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("FormaPago")]
    [MetadataType(typeof(IFormaPago))]
    public class FormaPago : EntidadBase
    {
        // Propiedades
        public long ComprobanteId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
    }
}
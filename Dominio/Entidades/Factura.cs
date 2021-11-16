using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_Factura")]
    [MetadataType(typeof(IFactura))]
    public class Factura : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }

        public long PuestoTrabajoId { get; set; }

        public Estado Estado { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }

        public virtual PuestoTrabajo PuestoTrabajo { get; set; }
    }
}

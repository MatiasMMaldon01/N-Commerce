using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("DetalleCaja")]
    [MetadataType(typeof(IDetalleCaja))]
    public class DetalleCaja : EntidadBase
    {
        // Propiedades
        public long CajaId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }


        // Propiedades de Navegacion
        public virtual Caja Caja { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("PuestoTrabajo")]
    [MetadataType(typeof(IPuestoTrabajo))]
    public class PuestoTrabajo : EntidadBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        // Propiedades de Navegacion

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}

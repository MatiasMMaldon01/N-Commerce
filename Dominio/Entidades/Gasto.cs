using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Gasto")]
    [MetadataType(typeof(IGasto))]
    public class Gasto : EntidadBase
    {
        // Propiedades
        public long ConceptoGastoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public virtual ConceptoGasto ConceptoGasto { get; set; }
    }
}

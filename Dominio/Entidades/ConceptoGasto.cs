using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("ConceptoGastos")]
    [MetadataType(typeof(IConceptoGasto))]
    public class ConceptoGasto : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
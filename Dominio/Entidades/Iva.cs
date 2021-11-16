using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Iva")]
    [MetadataType(typeof(IIva))]
    public class Iva : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
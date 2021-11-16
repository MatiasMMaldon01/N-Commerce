using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("MotivoBajas")]
    [MetadataType(typeof(IMotivoBaja))]
    public class MotivoBaja : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<BajaArticulo> BajaArticulos { get; set; }
    }
}
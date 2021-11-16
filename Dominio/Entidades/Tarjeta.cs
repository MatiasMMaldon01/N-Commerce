using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Tarjeta")]
    [MetadataType(typeof(ITarjeta))]
    public class Tarjeta : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<FormaPagoTarjeta> FormaPagoTarjetas { get; set; }
    }
}
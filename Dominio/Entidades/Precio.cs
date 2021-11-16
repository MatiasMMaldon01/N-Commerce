using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Precio")]
    [MetadataType(typeof(IPrecio))]
    public class Precio : EntidadBase
    {
        // Propiedades
        public long ArticuloId { get; set; }

        public long ListaPrecioId { get; set; }
        
        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public DateTime FechaActualizacion { get; set; }

        // Propiedades de Navegacion
        public virtual Articulo Articulo { get; set; }

        public virtual ListaPrecio ListaPrecio { get; set; }
    }
}
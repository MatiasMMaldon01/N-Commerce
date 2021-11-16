using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Rubro")]
    [MetadataType(typeof(IRubro))]
    public class Rubro : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        public bool ActivarHoraVenta { get; set; }
        public DateTime HoraLimiteVentaDesde { get; set; }
        public DateTime HoraLimiteVentaHasta { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
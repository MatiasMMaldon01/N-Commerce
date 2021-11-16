using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("CondicionIva")]
    [MetadataType(typeof(ICondicionIva))]
    public class CondicionIva : EntidadBase
    {
        // Propiedades 
        public string Descripcion { get; set; }


        // Propiedades de Navegacion
        public virtual ICollection<Proveedor> Proveedores { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

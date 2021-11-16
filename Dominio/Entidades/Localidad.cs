using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Localidad")]
    [MetadataType(typeof(ILocalidad))]
    public class Localidad : EntidadBase
    {
        // Propiedades
        public long DepartamentoId { get; set; }

        public string Descripcion { get; set; }


        // Propiedades de Navegacion
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }

        public virtual ICollection<Configuracion> Configuraciones { get; set; }
    }
}

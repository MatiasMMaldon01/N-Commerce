using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Persona")]
    [MetadataType(typeof(IPersona))]
    public class Persona : EntidadBase
    {
        // Propiedades
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public long LocalidadId { get; set; }


        // Propiedades de Navegacion
        public virtual Localidad Localidad { get; set; }
    }
}

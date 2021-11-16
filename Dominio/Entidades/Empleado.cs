using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Persona_Empleado")]
    [MetadataType(typeof(IEmpleado))]
    public class Empleado : Persona
    {
        // Propiedades
        public int Legajo { get; set; }

        public byte[] Foto { get; set; }


        // Propiedades de Navegacion
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}

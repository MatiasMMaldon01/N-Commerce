using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Departamento")]
    [MetadataType(typeof(IDepartamento))]
    public class Departamento : EntidadBase
    {
        public long ProvinciaId { get; set; }

        public string Descripcion { get; set; }

        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}

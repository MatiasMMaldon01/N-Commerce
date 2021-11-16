using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Banco")]
    [MetadataType(typeof(IBanco))]
    public class Banco : EntidadBase
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Cheque> Cheques { get; set; }

        public virtual ICollection<CuentaBancaria> CuentaBancarias { get; set; }
    }
}

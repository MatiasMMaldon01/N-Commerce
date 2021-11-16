using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Persona_Cliente")]
    [MetadataType(typeof(ICliente))]
    public class Cliente : Persona
    {
        // Propiedades 
        public long CondicionIvaId { get; set; }

        public bool ActivarCtaCte { get; set; }
        
        public bool TieneLimiteCompra { get; set; }
        
        public decimal MontoMaximoCtaCte { get; set; }


        // Propiedades de Navegación
        public virtual CondicionIva CondicionIva { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }

        public virtual ICollection<CuentaCorrienteCliente> CuentaCorrientes { get; set; }

        public virtual ICollection<Remito> Remitos { get; set; }

        public virtual ICollection<Presupuesto> Presupuestos { get; set; }

        public virtual ICollection<FormaPagoCtaCte> FormaPagoCtaCtes { get; set; }

        public virtual ICollection<MovimientoCuentaCorriente> MovimientoCuentaCorrientes { get; set; }


    }
}

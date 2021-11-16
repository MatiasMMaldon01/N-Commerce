using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("DepositoCheques")]
    [MetadataType(typeof(IDepositoCheque))]
    public class DepositoCheque : EntidadBase
    {
        // Propiedades
        public long ChequeId { get; set; }

        public long CuentaBancariaId { get; set; }

        public DateTime Fecha { get; set; }

        // Propiedades de Navegacion
        public virtual Cheque Cheque { get; set; }

        public virtual CuentaBancaria CuentaBancaria { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Caja")]
    [MetadataType(typeof(ICaja))]
    public class Caja : EntidadBase
    {
        // ==========================================//
        public long UsuarioAperturaId { get; set; }

        public decimal MontoInicial { get; set; }

        public DateTime FechaApertura { get; set; }

        // ==========================================//

        public long? UsuarioCierreId { get; set; }

        public DateTime? FechaCierre { get; set; }

        public decimal? MontoCierre { get; set; }

        // ==========================================//

        public decimal TotalEntradaEfectivo { get; set; }
        public decimal TotalSalidaEfectivo { get; set; }

        // ==========================================//
        public decimal TotalEntradaTarjeta { get; set; }
        public decimal TotalSalidaTarjeta { get; set; }

        // ==========================================//
        public decimal TotalEntradaCheque { get; set; }
        public decimal TotalSalidaCheque { get; set; }

        // ==========================================//
        public decimal TotalEntradaCtaCte { get; set; }
        public decimal TotalSalidaCtaCte { get; set; }


        // Propiedades de Navegacion
        public virtual Usuario UsuarioApertura { get; set; }

        public virtual Usuario UsuarioCierre { get; set; }

        public virtual ICollection<DetalleCaja> DetalleCajas { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}

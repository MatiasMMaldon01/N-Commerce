using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Movimiento")]
    [MetadataType(typeof(IMovimiento))]
    public class Movimiento : EntidadBase
    {
        // Propiedades
        public long CajaId { get; set; }

        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
        public virtual Caja Caja { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_Compra")]
    [MetadataType(typeof(ICompra))]
    public class Compra : Comprobante
    {
        // Propiedades
        public long ProveedorId { get; set; }

        public DateTime FechaEntrega { get; set; }

        public decimal Iva27 { get; set; }

        public decimal PrecepcionTemp { get; set; }

        public decimal PrecepcionPyP { get; set; }

        public decimal PrecepcionIva { get; set; }

        public decimal PrecepcionIB { get; set; }

        public Estado EstadoFactura { get; set; }


        // Propiedades de Navegacion
        public virtual Proveedor Proveedor { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("FormaPago_Tarjeta")]
    [MetadataType(typeof(IFormaPagoTarjeta))]
    public class FormaPagoTarjeta : FormaPago
    {
        public long TarjetaId { get; set; }

        public string NumeroTarjeta { get; set; }

        public string CuponPago { get; set; }

        public int CantidadCuotas { get; set; }

        // Propiedades de Navegacion
        public virtual Tarjeta Tarjeta { get; set; }
    }
}

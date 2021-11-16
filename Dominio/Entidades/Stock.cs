using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Stock")]
    [MetadataType(typeof(IStock))]
    public class Stock : EntidadBase
    {
        // Propiedades
        public long ArticuloId { get; set; }

        public long DepositoId { get; set; }

        public decimal Cantidad { get; set; }


        // Propiedades de Navegacion
        public Articulo Articulo { get; set; }

        public Deposito Deposito { get; set; }  
    }
}

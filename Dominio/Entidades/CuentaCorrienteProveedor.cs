using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Comprobante_CtaCteProveedor")]
    [MetadataType(typeof(ICuentaCorrienteProveedor))]

    public class CuentaCorrienteProveedor : Comprobante
    {
        // Propiedades
        public long ProveedorId { get; set; }

        public Estado Estado{ get; set; }

        // Propiedades de Navegacion
        public virtual Proveedor Proveedor { get; set; }
    }
}

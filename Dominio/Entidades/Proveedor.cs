using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Proveedor")]
    [MetadataType(typeof(IProveedor))]
    public class Proveedor : EntidadBase
    {
        public string RazonSocial { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public long LocalidadId { get; set; }

        public long CondicionIvaId { get; set; }


        // Propiedades de Navegacion

        public virtual Localidad Localidad { get; set; }

        public virtual CondicionIva CondicionIva { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

        public virtual ICollection<CuentaCorrienteProveedor> CuentaCorrienteProveedores { get; set; }

        public virtual ICollection<MovimientoCuentaCorrienteProveedor> MovimientoCuentaCorrienteProveedores { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.MetaData;

namespace Dominio.Entidades
{
    [Table("Usuario")]
    [MetadataType(typeof(IUsuario))]
    public class Usuario : EntidadBase
    {
        // Propiedades
        public long EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }


        // Propiedades de Navegacion
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("UsuarioAperturaId")]
        public virtual ICollection<Caja> CajaAperturas { get; set; }

        [ForeignKey("UsuarioCierreId")]
        public virtual ICollection<Caja> CajaCierres { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }

    }
}

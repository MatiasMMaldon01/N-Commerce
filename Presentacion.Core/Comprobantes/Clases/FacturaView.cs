using Aplicacion.Constantes;
using IServicio.Persona.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion.Core.Comprobantes.Clases
{
    public class FacturaView
    {
        public FacturaView()
        {
            if (Items == null)
                Items = new List<ItemView>();
        }

        public int ContadorItems { get; set; } = 0;

        //============================= Cabecera==================================//
        public ClienteDto Cliente { get; set; }

        public EmpleadoDto Vendedor { get; set; }

        public long PuntoVentaId { get; set; }

        public long UsuarioId { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        //=============================  Cuerpo ==================================//

        public List<ItemView> Items { get; set; }

        //=============================   Pie   ==================================//
        public decimal SubTotal => Items.Sum(x => x.SubTotal);
        public string SubTotalStr => SubTotal.ToString("C");
        public decimal Descuento { get; set; }
        public decimal Total => SubTotal - (SubTotal * (Descuento / 100m));
        public string TotalStr => Total.ToString("C");
    }
}

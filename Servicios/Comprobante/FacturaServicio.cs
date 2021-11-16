using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Comprobante
{
    public class FacturaServicio : ComprobanteServicio, IFacturaServicio
    {
        public FacturaServicio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {
           
        }

        public IEnumerable<ComprobantesPendientesDto> ObtenerCPendientes()
        {
            return _unidadDeTrabajo.FacturaRepositorio.Obtener(x => !x.EstaEliminado && x.Estado == Aplicacion.Constantes.Estado.Pendiente, "Cliente, DetalleComprobantes")
                .Select(x => new ComprobantesPendientesDto
                {
                    Id = x.Id,
                    Cliente = new IServicio.Persona.DTOs.ClienteDto
                    {
                        Id = x.Cliente.Id,
                        Dni = x.Cliente.Dni,
                        Nombre = x.Cliente.Nombre,
                        Apellido = x.Cliente.Apellido,
                        Telefono = x.Cliente.Telefono,
                        Direccion = x.Cliente.Direccion,
                        ActivarCtaCte = x.Cliente.ActivarCtaCte,
                        TieneLimiteCompra = x.Cliente.TieneLimiteCompra,
                        MontoMaximoCtaCte = x.Cliente.MontoMaximoCtaCte,
                        Eliminado = x.Cliente.EstaEliminado
                    },
                    ClienteApyNom = $"{x.Cliente.Apellido}, {x.Cliente.Nombre}",
                    Dni = x.Cliente.Dni,
                    Telefono = x.Cliente.Telefono,
                    Direccion = x.Cliente.Direccion,
                    MontoPagar=x.Total,
                    Fecha = x.Fecha,
                    TipoComprobante = x.TipoComprobante,
                    NroComprobante = x.Numero,
                    Eliminado=false,

                    Items = x.DetalleComprobantes.Select(c => new DetallePendienteDto
                    {
                        Id = c.Id,
                        Descripcion = c.Descripcion,
                        Cantidad = c.Cantidad,
                        Precio = c.Precio,
                        SubTotal = c.SubTotal,
                        Eliminado = c.EstaEliminado
                    }).ToList()
                }).OrderByDescending(x=>x.Fecha).ToList();
        }
    }
}

using IServicios.Caja.DTOs;
using Dominio.UnidadDeTrabajo;
using IServicios.Caja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Servicios.Base;
using Aplicacion.Constantes;

namespace Servicios.Caja
{
    public class CajaServicio : ICajaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public CajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void AbrirCaja(long usuarioId, decimal monto)
        {
            var nuevaCaja = new Dominio.Entidades.Caja
            {
                UsuarioAperturaId = usuarioId,
                FechaApertura = DateTime.Now,
                MontoInicial = monto,
                //----------------------------------//
                UsuarioCierreId = (long?)null,
                FechaCierre = (DateTime?)null,
                MontoCierre = (decimal?)null,
                //----------------------------------//
                TotalEntradaCheque = 0m,
                TotalEntradaCtaCte = 0m,
                TotalEntradaTarjeta = 0m,
                TotalEntradaEfectivo = 0m,
                TotalSalidaCheque = 0m,
                TotalSalidaCtaCte = 0m,
                TotalSalidaTarjeta = 0m,
                TotalSalidaEfectivo = 0m,
                //----------------------------------//

                EstaEliminado = false
            };
            _unidadDeTrabajo.CajaRepositorio.Insertar(nuevaCaja);
            _unidadDeTrabajo.Commit(); ;
        }      

        public decimal ObtenerMontoCierre(long usuarioId)
        {
            var cajasUsuario = _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == usuarioId && x.UsuarioCierre != null);

            if (cajasUsuario.Any())
            {
                var ultimaCaja = cajasUsuario.Where(x => x.FechaApertura == cajasUsuario.Max(f => f.FechaApertura)).LastOrDefault();

                if (ultimaCaja==null)
                {
                    return 0m;
                }
                else
                {
                    return ultimaCaja.MontoCierre.Value;
                }
            }
            else
            {
                return 0m;
            }
   
        }

        public bool VerificarSiEstaAbierta(long usuarioId)
        {
            return _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == usuarioId && x.UsuarioCierreId==null).Any();
        }

        public IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool activarFecha, DateTime fechaDesde, DateTime fechaHasta)
        {
            Expression<Func<Dominio.Entidades.Caja, bool>> filtro = x => x.UsuarioApertura.Nombre.Contains(cadenaBuscar) || x.UsuarioCierre.Nombre.Contains(cadenaBuscar);

            var _fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0);

            var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

            if (activarFecha)
            {
                filtro = filtro.And(x => x.FechaApertura >= _fechaDesde && x.FechaApertura <= _fechaHasta);
            }

            return _unidadDeTrabajo.CajaRepositorio.Obtener(filtro, "UsuarioApertura, UsuarioCierre")
            .Select(x => new CajaDto
            {
                Id = x.Id,
                // ----------------------------------------//
                UsuarioAperturaId = x.UsuarioAperturaId,
                UsuarioApertura = x.UsuarioApertura.Nombre,
                FechaApertura = x.FechaApertura,
                MontoApertura = x.MontoInicial,
                // ----------------------------------------//
                UsuarioCierreId = x.UsuarioCierreId,
                UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : "----",
                FechaCierre = x.FechaCierre,
                MontoCierre = x.MontoCierre,
                // ----------------------------------------//
                TotalEntradaCheque = x.TotalEntradaCheque,
                TotalEntradaCtaCte = x.TotalEntradaCtaCte,
                TotalEntradaEfectivo = x.TotalEntradaEfectivo,
                TotalEntradaTarjeta = x.TotalEntradaTarjeta,
                TotalSalidaCheque = x.TotalSalidaCheque,
                TotalSalidaCtaCte = x.TotalSalidaCtaCte,
                TotalSalidaEfectivo = x.TotalSalidaEfectivo,
                TotalSalidaTarjeta = x.TotalSalidaTarjeta,
                // ----------------------------------------//
                Eliminado = x.EstaEliminado

            }).ToList();
        }

        public CajaDto Obtener(long usuarioId)
        {
            return _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == usuarioId && x.UsuarioCierreId==null, "UsuarioApertura, UsuarioCierre, DetalleCajas, Movimientos, Movimientos.Comprobante, Movimientos.Comprobante.Empleado")
            .Select(x => new CajaDto
            {
                Id = x.Id,
                // ----------------------------------------//
                UsuarioAperturaId = x.UsuarioAperturaId,
                UsuarioApertura = x.UsuarioApertura.Nombre,
                FechaApertura = x.FechaApertura,
                MontoApertura = x.MontoInicial,
                // ----------------------------------------//
                UsuarioCierreId = x.UsuarioCierreId,
                UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : "----",
                FechaCierre = x.FechaCierre,
                MontoCierre = x.MontoCierre,
                // ----------------------------------------//
                TotalEntradaCheque = x.TotalEntradaCheque,
                TotalEntradaCtaCte = x.TotalEntradaCtaCte,
                TotalEntradaEfectivo = x.TotalEntradaEfectivo,
                TotalEntradaTarjeta = x.TotalEntradaTarjeta,
                TotalSalidaCheque = x.TotalSalidaCheque,
                TotalSalidaCtaCte = x.TotalSalidaCtaCte,
                TotalSalidaEfectivo = x.TotalSalidaEfectivo,
                TotalSalidaTarjeta = x.TotalSalidaTarjeta,
                // ----------------------------------------//

                Detalles = x.DetalleCajas.Select(d => new CajaDetalleDto
                {
                    Monto = d.Monto,
                    TipoPago = d.TipoPago,
                    Eliminado = d.EstaEliminado
                }).ToList(),

                Comprobantes = x.Movimientos.Select(c => new ComprobanteDeCajaDto
                {
                    Vendedor = $" {c.Comprobante.Empleado.Apellido}, {c.Comprobante.Empleado.Nombre}",
                    Fecha = c.Fecha,
                    Descuento = c.Comprobante.Descuento,
                    Numero = c.Comprobante.Numero,
                    SubTotal = c.Comprobante.SubTotal,
                    Total = c.Comprobante.Total,
                    TipoComprobante = c.Comprobante.TipoComprobante,
                    Eliminado = c.Comprobante.EstaEliminado
                }).ToList(),
                Eliminado = x.EstaEliminado

            }).FirstOrDefault();
        }

        public void CerrarCaja(long cajaId, decimal montoCierre)
        {
           var cajaCerrar= _unidadDeTrabajo.CajaRepositorio.Obtener(cajaId);

            cajaCerrar.FechaCierre = DateTime.Now;
            cajaCerrar.UsuarioCierreId = Identidad.UsuarioId;
            cajaCerrar.MontoCierre = montoCierre;

            _unidadDeTrabajo.CajaRepositorio.Modificar(cajaCerrar);
            _unidadDeTrabajo.Commit();

        }
    }
}

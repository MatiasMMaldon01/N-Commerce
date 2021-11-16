using Aplicacion.Constantes;
using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using IServicios.CuentaCorriente;
using IServicios.CuentaCorriente.Dtos;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.CuentaCorriente
{
    public class CuentaCorrienteServicio : ICuentaCorrienteServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IContadorServicio _contadorServicio;
        private readonly ICtaCteComprobanteServicio _ctaCteComprobanteServicio;

        public CuentaCorrienteServicio(IUnidadDeTrabajo unidadDeTRabajo, IContadorServicio contadorServicio, ICtaCteComprobanteServicio ctaCteComprobanteServicio)
        {
            _unidadDeTrabajo = unidadDeTRabajo;
            _contadorServicio = contadorServicio;
            _ctaCteComprobanteServicio = ctaCteComprobanteServicio;
        }

        public decimal ObtenerDeudaCliente(long clienteId)
        {
            var movimientos = _unidadDeTrabajo.CuentaCorrienteRepositorio.Obtener(x => !x.EstaEliminado && x.ClienteId == clienteId);

            return movimientos.Sum(x => x.Monto * (int)x.TipoMovimiento);
        }

        public IEnumerable<CuentaCorrienteDto> Obtener(long clienteId, bool filtroFecha, DateTime fechaDesde, DateTime fechaHasta)
        {
            var _fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0);
            var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

            Expression<Func<MovimientoCuentaCorriente, bool>> filtro = x => x.ClienteId==clienteId;

            filtro = filtro.And(x => x.Fecha >= _fechaDesde && x.Fecha <= _fechaHasta);
            return _unidadDeTrabajo.CuentaCorrienteRepositorio.Obtener(filtro)
                .Select(x => new CuentaCorrienteDto
                {
                    Fecha=x.Fecha,
                    Descripcion= x.Descripcion,
                    Monto=(x.Monto* (int) x.TipoMovimiento)

                }).OrderByDescending(x => x.Fecha).ToList();

        }

        public void Pagar(CtaCteComprobanteDto comprobanteDto)
        {
            try
            {
                _ctaCteComprobanteServicio.Insertar(comprobanteDto);
            }
            catch 
            {
                throw new Exception("Ocurrio un error al pagar la deuda");
            }
        }

        public void CancelarPago(long pagoId)
        {
            _ctaCteComprobanteServicio.Eliminar(pagoId);
        }
    }
}

using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente.Dtos;
using System;
using System.Collections.Generic;

namespace IServicios.CuentaCorriente
{
    public interface ICuentaCorrienteServicio
    {
        decimal ObtenerDeudaCliente(long clienteId);

        IEnumerable<CuentaCorrienteDto> Obtener(long clienteId, bool filtroFecha, DateTime fechaDesde, DateTime fechaHasta);

        void Pagar(CtaCteComprobanteDto comprobanteDto);

        void CancelarPago(long pagoId);

    }
}

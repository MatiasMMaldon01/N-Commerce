using IServicios.Caja.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.Caja
{
    public interface ICajaServicio
    {
        bool VerificarSiEstaAbierta(long usuarioId);

        decimal ObtenerMontoCierre(long usuarioId);

        void AbrirCaja(long usuarioId, decimal monto);

        void CerrarCaja(long cajaId, decimal montoCierre);

        IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool activarFecha, DateTime fechaDesde, DateTime fechaHasta);

        CajaDto Obtener(long usuarioId);
    }
}

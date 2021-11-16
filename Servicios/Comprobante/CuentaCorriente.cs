using Aplicacion.Constantes;
using Dominio.Entidades;
using IServicio.Configuracion;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class CuentaCorriente : Comprobante
    {

        private readonly IContadorServicio _contadorServicio;      

        public CuentaCorriente()
        : base()
        {
            _contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
        }

        public override long Insertar(ComprobanteDto comprobante)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    int numeroComprobante=0;

                    numeroComprobante = _contadorServicio.ObtenerSiguienteNumeroComprobante(comprobante.TipoComprobante);                 

                    var cajaActual = _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == comprobante.UsuarioId
                                                                                && x.UsuarioCierreId == null, "DetalleCajas").FirstOrDefault();
                    if (cajaActual == null)
                        throw new Exception("Ocurrio un error al obtener la Caja");

                    var CtaCteComprobanteDto = (CtaCteComprobanteDto)comprobante;

                    CuentaCorrienteCliente _CtaCteNueva = new CuentaCorrienteCliente();

                    numeroComprobante = _contadorServicio.ObtenerSiguienteNumeroComprobante(comprobante.TipoComprobante);

                        _CtaCteNueva = new CuentaCorrienteCliente
                        {
                            ClienteId = CtaCteComprobanteDto.ClienteId,
                            Descuento = CtaCteComprobanteDto.Descuento,
                            EmpleadoId = CtaCteComprobanteDto.EmpleadoId,
                            Fecha = CtaCteComprobanteDto.Fecha,
                            Iva105 = CtaCteComprobanteDto.Iva105,
                            Iva21 = CtaCteComprobanteDto.Iva21,
                            Numero = numeroComprobante,
                            SubTotal = CtaCteComprobanteDto.SubTotal,
                            Total = CtaCteComprobanteDto.Total,
                            TipoComprobante = CtaCteComprobanteDto.TipoComprobante,
                            UsuarioId = CtaCteComprobanteDto.UsuarioId,
                            DetalleComprobantes = new List<DetalleComprobante>(),
                            Movimientos = new List<Movimiento>(),
                            FormaPagos = new List<FormaPago>(),
                            EstaEliminado = false
                        };

                        _CtaCteNueva.Movimientos.Add(new Movimiento
                        {                           
                            ComprobanteId = _CtaCteNueva.Id,
                            CajaId = cajaActual.Id,
                            Fecha = CtaCteComprobanteDto.Fecha,
                            Monto = CtaCteComprobanteDto.Total,
                            UsuarioId = CtaCteComprobanteDto.UsuarioId,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            Descripcion = $"Pago Cta Cte- {CtaCteComprobanteDto.TipoComprobante.ToString()}-Nro {numeroComprobante}",
                            EstaEliminado = false
                        });

                        foreach (var fp in CtaCteComprobanteDto.FormasDePagos)
                        {
                                var fpCtaCTe = (FormaPagoCtaCteDto)fp;
                                _CtaCteNueva.FormaPagos.Add(new FormaPagoCtaCte
                                {
                                    ComprobanteId = _CtaCteNueva.Id,
                                    Monto = fpCtaCTe.Monto,
                                    TipoPago = TipoPago.CtaCte,
                                    ClienteId = fpCtaCTe.ClienteId,
                                    EstaEliminado = false
                                });

                                _CtaCteNueva.Movimientos.Add(new MovimientoCuentaCorriente
                                {
                                    CajaId = cajaActual.Id,
                                    Fecha = CtaCteComprobanteDto.Fecha,
                                    Monto = fpCtaCTe.Monto,
                                    UsuarioId = CtaCteComprobanteDto.UsuarioId,
                                    TipoMovimiento = TipoMovimiento.Ingreso,
                                    ComprobanteId = _CtaCteNueva.Id,
                                    Descripcion = $"Pago Cta Cte-{CtaCteComprobanteDto.TipoComprobante.ToString()}-Nro{numeroComprobante}",
                                    ClienteId = fpCtaCTe.ClienteId,
                                    EstaEliminado = false
                                });

                                cajaActual.TotalEntradaCtaCte += fpCtaCTe.Monto;
                                cajaActual.DetalleCajas.Add(new DetalleCaja
                                {
                                    CajaId = cajaActual.Id,
                                    Monto = fpCtaCTe.Monto,
                                    TipoPago = TipoPago.CtaCte
                                });

                        }
                        

                    _unidadDeTrabajo.CajaRepositorio.Modificar(cajaActual);
                    
                    _unidadDeTrabajo.CtaCteClienteComprobanteRepositorio.Insertar(_CtaCteNueva);

                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                    return 0;
                }
                catch
                {
                    tran.Dispose();
                    throw new Exception("Ocurrio un error grave al grabar la Factura");
                }
            };
        }

        public void Eliminar (long pagoId)
        {
            _unidadDeTrabajo.CtaCteClienteComprobanteRepositorio.Eliminar(pagoId);
            _unidadDeTrabajo.Commit();
        }
    }
}

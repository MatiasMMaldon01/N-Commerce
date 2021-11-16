using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Aplicacion.Constantes;
using Dominio.Entidades;
using IServicio.Configuracion;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using StructureMap;

namespace Servicios.Comprobante
{
    public class Factura : Comprobante
    {
        private readonly IContadorServicio _contadorServicio;
        private readonly IConfiguracionServicio _configuracionServicio;

        public Factura()
        : base()
        {
            _contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
            _configuracionServicio =ObjectFactory.GetInstance<IConfiguracionServicio>();
        }

        public override long Insertar(ComprobanteDto comprobante)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    int numeroComprobante = 0;

                    var config = _configuracionServicio.Obtener();
                    if (config == null)
                        throw new Exception("Ocurrio un erorr al obtener la Configuración");
                       
                    var cajaActual = _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.UsuarioAperturaId == comprobante.UsuarioId
                                                                                    && x.UsuarioCierreId == null, "DetalleCajas").FirstOrDefault();
                    if (cajaActual == null)
                        throw new Exception("Ocurrio un error al obtener la Caja");
                       

                    var facturaDto = (FacturaDto)comprobante;

                    Dominio.Entidades.Factura _nuevaFactura= new Dominio.Entidades.Factura();

                    if (facturaDto.Estado == Estado.Pendiente && !facturaDto.VieneDeVentas)
                    {
                        _nuevaFactura = _unidadDeTrabajo.FacturaRepositorio.Obtener(facturaDto.Id, "DetalleComprobantes, Movimientos, FormaPagos");

                        if (_nuevaFactura == null) 
                            throw new Exception("Ocurrio un Error al obtener la Factura");
                        numeroComprobante = _nuevaFactura.Numero;
                        facturaDto.Estado = Estado.Pagada;
                        _nuevaFactura.Estado = Estado.Pagada;
                    }
                    else
                    {
                        numeroComprobante = _contadorServicio.ObtenerSiguienteNumeroComprobante(comprobante.TipoComprobante);

                        _nuevaFactura = new Dominio.Entidades.Factura
                        {
                            ClienteId = facturaDto.ClienteId,
                            Descuento = facturaDto.Descuento,
                            EmpleadoId = facturaDto.EmpleadoId,
                            Estado = facturaDto.Estado,
                            Fecha = facturaDto.Fecha,
                            Iva105 = facturaDto.Iva105,
                            Iva21 = facturaDto.Iva21,
                            Numero = numeroComprobante,
                            SubTotal = facturaDto.SubTotal,
                            Total = facturaDto.Total,
                            PuestoTrabajoId = facturaDto.PuestoTrabajoId,
                            TipoComprobante = facturaDto.TipoComprobante,
                            UsuarioId = facturaDto.UsuarioId,
                            DetalleComprobantes = new List<DetalleComprobante>(),
                            Movimientos = new List<Movimiento>(),
                            FormaPagos = new List<FormaPago>(),
                            EstaEliminado = false
                        };

                        foreach (var item in facturaDto.Items)
                        {
                            if (config.FacturaDescuentaStock)
                            {
                                var stockActual = _unidadDeTrabajo.StockRepositorio.Obtener(x => x.ArticuloId == item.ArticuloId
                                                                        && x.DepositoId == config.DepositoIdVenta).FirstOrDefault();

                                if (stockActual == null)
                                    throw new Exception("Ocurrio un error al obtener el Stock del Articulo");

                                if (stockActual.Cantidad >= item.Cantidad)
                                {
                                    stockActual.Cantidad -= item.Cantidad;
                                }
                                _unidadDeTrabajo.StockRepositorio.Modificar(stockActual);
                            }

                            _nuevaFactura.DetalleComprobantes.Add(new DetalleComprobante
                            {
                                Cantidad = item.Cantidad,
                                ArticuloId = item.ArticuloId,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Codigo = item.Codigo,
                                Iva = item.Iva,
                                SubTotal = item.SubTotal
                            });
                        }
                    }

                    if (facturaDto.Estado == Estado.Pagada)
                    {
                        _nuevaFactura.Movimientos.Add(new Movimiento
                        {
                            ComprobanteId=_nuevaFactura.Id,
                            CajaId = cajaActual.Id,
                            Fecha = facturaDto.Fecha,
                            Monto = facturaDto.Total,
                            UsuarioId = facturaDto.UsuarioId,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            Descripcion = $"Fa- {facturaDto.TipoComprobante.ToString()}-Nro {numeroComprobante}",
                            EstaEliminado = false
                        });

                        foreach (var fp in facturaDto.FormasDePagos)
                        {
                            switch (fp.TipoPago)
                            {
                                case TipoPago.Efectivo:
                                    _nuevaFactura.FormaPagos.Add(new FormaPago
                                    {
                                        ComprobanteId = _nuevaFactura.Id,
                                        Monto = fp.Monto,
                                        TipoPago = fp.TipoPago,
                                        EstaEliminado = false
                                    });

                                    cajaActual.TotalEntradaEfectivo += fp.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        CajaId= cajaActual.Id,
                                        Monto = fp.Monto,
                                        TipoPago = TipoPago.Efectivo
                                    });
                                    break;

                                case TipoPago.Tarjeta:
                                    var fpTarjeta = (FormaPagoTarjetaDto)fp;
                                    _nuevaFactura.FormaPagos.Add(new FormaPagoTarjeta
                                    {
                                        ComprobanteId = _nuevaFactura.Id,
                                        Monto = fpTarjeta.Monto,
                                        TipoPago = fpTarjeta.TipoPago,
                                        CantidadCuotas = fpTarjeta.CantidadCuotas,
                                        CuponPago = fpTarjeta.CuponPago,
                                        NumeroTarjeta = fpTarjeta.NumeroTarjeta,
                                        TarjetaId = fpTarjeta.TarjetaId,
                                        EstaEliminado = false
                                    });
                                    cajaActual.TotalEntradaTarjeta += fpTarjeta.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        CajaId= cajaActual.Id,
                                        Monto = fpTarjeta.Monto,
                                        TipoPago = TipoPago.Tarjeta
                                    });
                                    break;

                                case TipoPago.Cheque:
                                    var fpCheque = (FormaPagoChequeDto)fp;
                                    _nuevaFactura.FormaPagos.Add(new FormaPagoCheque
                                    {
                                        ComprobanteId = _nuevaFactura.Id,
                                        Cheque = new Cheque
                                        {
                                            BancoId = fpCheque.BancoId,
                                            ClienteId = fpCheque.ClienteId,
                                            FechaVencimiento = fpCheque.FechaVencimiento,
                                            Numero = fpCheque.Numero,
                                            EstaRechazado = false,
                                            EstaEliminado = false
                                        },
                                        Monto = fpCheque.Monto,
                                        TipoPago = TipoPago.Cheque
                                    });
                                    cajaActual.TotalEntradaCheque += fpCheque.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        CajaId = cajaActual.Id,
                                        Monto = fpCheque.Monto,
                                        TipoPago = TipoPago.Cheque
                                    });
                                    break;

                                case TipoPago.CtaCte:
                                    var fpCtaCTe = (FormaPagoCtaCteDto)fp;
                                    _nuevaFactura.FormaPagos.Add(new FormaPagoCtaCte
                                    {
                                        ComprobanteId = _nuevaFactura.Id,
                                        Monto = fpCtaCTe.Monto,
                                        TipoPago = TipoPago.CtaCte,
                                        ClienteId = fpCtaCTe.ClienteId,
                                        EstaEliminado = false
                                    });

                                    _nuevaFactura.Movimientos.Add(new MovimientoCuentaCorriente
                                    {
                                        CajaId = cajaActual.Id,
                                        Fecha = facturaDto.Fecha,
                                        Monto = fpCtaCTe.Monto,
                                        UsuarioId = facturaDto.UsuarioId,
                                        TipoMovimiento = TipoMovimiento.Egreso,
                                        ComprobanteId = _nuevaFactura.Id,
                                        Descripcion = $"Fa-{facturaDto.TipoComprobante.ToString()}-Nro{numeroComprobante}",
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
                                    break;
                            }
                        }

                        _unidadDeTrabajo.CajaRepositorio.Modificar(cajaActual);
                    }

                    if (facturaDto.VieneDeVentas)
                    {
                        _unidadDeTrabajo.FacturaRepositorio.Insertar(_nuevaFactura);
                    }
                    else
                    {
                        _unidadDeTrabajo.FacturaRepositorio.Modificar(_nuevaFactura);
                    }
                  
                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                    return 0;
                }
                catch 
                {
                    tran.Dispose();
                    throw new Exception ("Ocurrio un error grave al grabar la Factura");
                }
            };
        }

    }
}

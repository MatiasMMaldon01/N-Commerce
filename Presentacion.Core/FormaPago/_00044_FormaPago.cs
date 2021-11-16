using Aplicacion.Constantes;
using IServicio.Persona.DTOs;
using IServicios.Banco;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente;
using IServicios.Tarjeta;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes.Clases;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.FormaPago
{
    public partial class _00044_FormaPago : FormBase
    {
        public bool RealizoVenta { get; set; } = false;

        private FacturaView _factura;
        private ComprobantesPendientesDto _facturaPendiente;
        private bool _vieneDesdeVentas;

        private readonly IBancoServicio _bancoServicio;
        private readonly ITarjetaServicio _tarjetaServicio;
        private readonly IFacturaServicio _facturaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;

        public _00044_FormaPago(FacturaView factura) 
            : this()
        {
            InitializeComponent();

            _factura = factura;
            _vieneDesdeVentas = true;

            CargarDatos(_factura);
        }

        public _00044_FormaPago(ComprobantesPendientesDto facturaPendiente)
            :this()
        {
            InitializeComponent();

            _facturaPendiente = facturaPendiente;
            _vieneDesdeVentas = false;
            CargarDatos(facturaPendiente);
        }

        public _00044_FormaPago()
        {
            _bancoServicio = ObjectFactory.GetInstance<IBancoServicio>();
            _tarjetaServicio = ObjectFactory.GetInstance<ITarjetaServicio>();
            _facturaServicio = ObjectFactory.GetInstance<IFacturaServicio>();
            _cuentaCorrienteServicio = ObjectFactory.GetInstance<ICuentaCorrienteServicio>();
            
        }

        private void nudMontoEfectivo_ValueChanged(object sender, EventArgs e)
        {
            nudTotalEfectivo.Value = nudMontoEfectivo.Value;
        }

        private void nudMontoTarjeta_ValueChanged(object sender, EventArgs e)
        {
            nudTotalTarjeta.Value = nudMontoTarjeta.Value;
        }

        private void nudMontoCheque_ValueChanged(object sender, EventArgs e)
        {
            nudTotalCheque.Value = nudMontoCheque.Value;
        }

        private void nudMontoCtaCte_ValueChanged(object sender, EventArgs e)
        {
            nudTotalCtaCte.Value = nudMontoCtaCte.Value;
        }

        private void nudTotales_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = nudTotalCheque.Value+ nudTotalEfectivo.Value + nudTotalCtaCte.Value + nudTotalTarjeta.Value;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
            fLookUpCliente.ShowDialog();

            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                var _clienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;

                if (_clienteSeleccionado.ActivarCtaCte)
                {
                    txtApellido.Text = _clienteSeleccionado.ApyNom;
                    txtDni.Text = _clienteSeleccionado.Dni;
                    txtTelefono.Text = _clienteSeleccionado.Telefono;
                    txtDireccion.Text = _clienteSeleccionado.Direccion;

                    if (_facturaPendiente.Cliente.Dni != Aplicacion.Constantes.Cliente.ConsumidorFinal)
                    {
                        txtMontoAdeudado.Text = _cuentaCorrienteServicio.ObtenerDeudaCliente(_facturaPendiente.Cliente.Id).ToString("C");
                    }
                    else
                    {
                        txtMontoAdeudado.Text = 0.ToString("C");
                    }

                    if (_vieneDesdeVentas)
                    {
                        _factura.Cliente = _clienteSeleccionado;
                    }
                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show($"El cliente {_clienteSeleccionado.ApyNom} no activo la Cuenta Corriente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void nudPagaCon_ValueChanged(object sender, EventArgs e)
        {
            if (nudPagaCon.Value > 0)
            {
                CalcularVuelto();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_vieneDesdeVentas)
                {
                    if (nudTotal.Value > _factura.Total)
                    {
                        if (MessageBox.Show("El total que esta por abonar es superior al monto a pagar. Desea continuar? ", "Atención",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (nudTotal.Value < _factura.Total)
                    {
                        MessageBox.Show("El total que esta por abonar es inferior al monto a pagar", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (nudTotal.Value > _facturaPendiente.MontoPagar)
                    {
                        if (MessageBox.Show("El total que esta por abonar es superior al monto a pagar. Desea continuar? ", "Atención",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (nudTotal.Value < _facturaPendiente.MontoPagar)
                    {
                        MessageBox.Show("El total que esta por abonar es inferior al monto a pagar", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                var _nuevaFactura = new FacturaDto();

                if (_vieneDesdeVentas)
                {
                    _nuevaFactura.EmpleadoId = _factura.Vendedor.Id;
                    _nuevaFactura.ClienteId = _factura.Cliente.Id;
                    _nuevaFactura.UsuarioId = _factura.UsuarioId;
                    _nuevaFactura.Fecha = DateTime.Now;
                    _nuevaFactura.SubTotal = _factura.SubTotal;
                    _nuevaFactura.Descuento = _factura.Descuento;
                    _nuevaFactura.Total = _factura.Total;
                    _nuevaFactura.TipoComprobante = _factura.TipoComprobante;
                    _nuevaFactura.Estado = Estado.Pagada;
                    _nuevaFactura.VieneDeVentas = true;
                    _nuevaFactura.PuestoTrabajoId = _factura.PuntoVentaId;                
                    _nuevaFactura.Iva105 = 0;
                    _nuevaFactura.Iva21 = 0;

                    foreach (var item in _factura.Items)
                    {
                        _nuevaFactura.Items.Add(new DetalleComprobanteDto
                        {
                            Cantidad = item.Cantidad,
                            Iva = item.Iva,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            ArticuloId = item.ArticuloId,
                            Codigo = item.CodigoBarra,
                            SubTotal = item.SubTotal,
                            Eliminado = false,
                        });
                    }
                }
                else
                {
                    _nuevaFactura.Id = _facturaPendiente.Id;
                    _nuevaFactura.ClienteId = _facturaPendiente.Cliente.Id;
                    _nuevaFactura.Fecha = DateTime.Now;
                    _nuevaFactura.Numero = _facturaPendiente.NroComprobante;
                    _nuevaFactura.Descuento = 0;
                    _nuevaFactura.UsuarioId = Identidad.UsuarioId;
                    _nuevaFactura.Total = _facturaPendiente.MontoPagar;
                    _nuevaFactura.TipoComprobante = _facturaPendiente.TipoComprobante;
                    _nuevaFactura.Estado = Estado.Pendiente;
                    _nuevaFactura.VieneDeVentas = false;
                    _nuevaFactura.Iva105 = 0;
                    _nuevaFactura.Iva21 = 0;

                    foreach (var item in _facturaPendiente.Items)
                    {
                        _nuevaFactura.Items.Add(new DetalleComprobanteDto
                        {
                            Cantidad = item.Cantidad,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            SubTotal = item.SubTotal,
                            Eliminado = false,
                        });
                    }
                }

                if (nudTotalEfectivo.Value > 0)
                {
                    _nuevaFactura.FormasDePagos.Add(new FormaPagoDto
                    {
                        Monto = nudTotalEfectivo.Value,
                        TipoPago = TipoPago.Efectivo,
                        Eliminado = false
                    });
                }

                if (nudTotalTarjeta.Value > 0)
                {
                    _nuevaFactura.FormasDePagos.Add(new FormaPagoTarjetaDto
                    {
                        TipoPago = TipoPago.Tarjeta,
                        CantidadCuotas = (int)nudCantidadCuotas.Value,
                        CuponPago = txtCuponPago.Text,
                        Monto = nudTotalTarjeta.Value,
                        NumeroTarjeta = txtNumeroTarjeta.Text,
                        TarjetaId = (long)cmbTarjetaFP.SelectedValue,
                        Eliminado = false
                    });
                }

                if (nudTotalCheque.Value > 0)
                {
                    _nuevaFactura.FormasDePagos.Add(new FormaPagoChequeDto
                    {
                        BancoId = (long)cmbBancoFP.SelectedValue,
                        ClienteId = _factura.Cliente.Id,
                        FechaVencimiento = dtpFechaVencimientoCheque.Value,
                        Monto = nudTotalCheque.Value,
                        Numero = txtNumeroCheque.Text,
                        TipoPago = TipoPago.Cheque,
                        Eliminado = false
                    });
                }

                if (nudTotalCtaCte.Value>0)
                {
                    var deuda = _vieneDesdeVentas ? _cuentaCorrienteServicio.ObtenerDeudaCliente(_factura.Cliente.Id) : _cuentaCorrienteServicio.ObtenerDeudaCliente(_facturaPendiente.Cliente.Id);

                    if (_vieneDesdeVentas)
                    {                        
                        if (_factura.Cliente.ActivarCtaCte)
                        {
                            if (_factura.Cliente.TieneLimiteCompra && _factura.Cliente.MontoMaximoCtaCte < deuda + nudTotalCtaCte.Value)
                            {
                                var menssajeCtaCte = $"El cliente {_factura.Cliente.ApyNom} se sobreexcedio de su limite de cuenta"
                                                                    + Environment.NewLine+ $" El limite en su cuenta es { _factura.Cliente.MontoMaximoCtaCte.ToString("C")}";
                                    MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            _nuevaFactura.FormasDePagos.Add(new FormaPagoCtaCteDto
                            {
                                TipoPago = TipoPago.CtaCte,
                                ClienteId = _factura.Cliente.Id,
                                Monto = nudTotalCtaCte.Value,
                                Eliminado = false,
                            });
                        }
                    }                   
                    else
                    {
                        if (_facturaPendiente.Cliente.ActivarCtaCte)
                        {
                            if (_facturaPendiente.Cliente.TieneLimiteCompra && _facturaPendiente.Cliente.MontoMaximoCtaCte < deuda + nudTotalCtaCte.Value)
                            {
                                var menssajeCtaCte = $"El cliente {_facturaPendiente.Cliente.ApyNom} se sobreexcedio de su limite de cuenta"
                                                                    + Environment.NewLine + $" El limite en su cuenta es { _factura.Cliente.MontoMaximoCtaCte.ToString("C")}";
                                MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            _nuevaFactura.FormasDePagos.Add(new FormaPagoCtaCteDto
                            {
                                TipoPago = TipoPago.CtaCte,
                                ClienteId = _facturaPendiente.Cliente.Id,
                                Monto = nudTotalCtaCte.Value,
                                Eliminado = false,
                            });
                        }
                    }
                }

                _facturaServicio.Insertar(_nuevaFactura);
                RealizoVenta = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RealizoVenta = false;

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            RealizoVenta = false;
            this.Close();
        }

        private void CargarDatos(FacturaView factura)
        {
            txtTotalAbonar.Text = factura.TotalStr;
            nudMontoEfectivo.Value = factura.Total;
            nudMontoCheque.Value = 0;
            txtNumeroCheque.Clear();
            dtpFechaVencimientoCheque.Value = DateTime.Now;
            nudMontoCtaCte.Value = 0;
            txtApellido.Text = factura.Cliente.ApyNom;
            txtDni.Text = factura.Cliente.Dni;
            txtTelefono.Text = factura.Cliente.Telefono;
            txtDireccion.Text = factura.Cliente.Direccion;
            nudMontoTarjeta.Value = 0;
            txtNumeroTarjeta.Clear();
            txtCuponPago.Clear();
            nudCantidadCuotas.Value = 1;
            if (factura.Cliente.Dni != Aplicacion.Constantes.Cliente.ConsumidorFinal)
            {
                txtMontoAdeudado.Text = _cuentaCorrienteServicio.ObtenerDeudaCliente(factura.Cliente.Id).ToString("C");
            }
            else
            {
                txtMontoAdeudado.Text = 0.ToString("C");
            }

            PoblarComboBox(cmbBancoFP, _bancoServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbTarjetaFP, _tarjetaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

        private void CargarDatos(ComprobantesPendientesDto facturaPendiente)
        {
            txtTotalAbonar.Text = facturaPendiente.MontoPagarStr;
            nudMontoEfectivo.Value = facturaPendiente.MontoPagar;
            nudMontoCheque.Value = 0;
            txtNumeroCheque.Clear();
            dtpFechaVencimientoCheque.Value = DateTime.Now;
            nudMontoCtaCte.Value = 0;
            txtApellido.Text = facturaPendiente.Cliente.Apellido;
            txtDni.Text = facturaPendiente.Dni;
            txtTelefono.Text = facturaPendiente.Telefono;
            txtDireccion.Text = facturaPendiente.Direccion;
            if (facturaPendiente.Cliente.Dni != Aplicacion.Constantes.Cliente.ConsumidorFinal)
            {
                txtMontoAdeudado.Text = _cuentaCorrienteServicio.ObtenerDeudaCliente(facturaPendiente.Cliente.Id).ToString("C");
            }
            else
            {
                txtMontoAdeudado.Text = 0.ToString("C");
            }
            nudMontoTarjeta.Value = 0;
            txtNumeroTarjeta.Clear();
            txtCuponPago.Clear();
            nudCantidadCuotas.Value = 1;

            PoblarComboBox(cmbBancoFP, _bancoServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbTarjetaFP, _tarjetaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
        }

        private void CalcularVuelto()
        {
            nudVuelto.Value = nudTotalEfectivo.Value - nudPagaCon.Value >= 0
                             ? nudPagaCon.Value - nudTotalEfectivo.Value
                             : (nudTotalEfectivo.Value - nudPagaCon.Value) * -1;
        }

        private void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            var fNuevaUnidad = new _00046_Abm_tarjeta(TipoOperacion.Nuevo);
            fNuevaUnidad.ShowDialog();
            if (fNuevaUnidad.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbTarjetaFP, _tarjetaServicio.Obtener(string.Empty, false));
            }
        }

        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            var fNuevaUnidad = new _00048_Abm_Banco(TipoOperacion.Nuevo);
            fNuevaUnidad.ShowDialog();
            if (fNuevaUnidad.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbBancoFP, _bancoServicio.Obtener(string.Empty, false));
            }
        }
    }
}

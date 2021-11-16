using Aplicacion.Constantes;
using IServicio.Persona.DTOs;
using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class _00035_ClientePagoCtaCte : FormBase
    {
        private readonly ClienteDto _cliente;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;

        public bool RealizoPago { get; internal set; }

        public _00035_ClientePagoCtaCte(ClienteDto cliente)
        {
            InitializeComponent();

            _cliente = cliente;

            _cuentaCorrienteServicio = ObjectFactory.GetInstance<ICuentaCorrienteServicio>();

            RealizoPago = false;
        }
     
        private void _00035_ClientePagoCtaCte_Load(object sender, System.EventArgs e)
        {
            if (_cliente!= null)
            {
                nudMontoDeuda.Value = _cuentaCorrienteServicio.ObtenerDeudaCliente(_cliente.Id);
                nudMontoPagar.Select(0, nudMontoPagar.Text.Length);

                nudMontoPagar.Focus();
            }
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            RealizoPago = false;
            this.Close();
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            nudMontoPagar.Value = 0;
            nudMontoPagar.Select(0, nudMontoPagar.Text.Length);
            nudMontoPagar.Focus();
        }

        private void btnPagar_Click(object sender, System.EventArgs e)
        {
            if (nudMontoPagar.Value> 0)
            {
                if ((nudMontoPagar.Value * -1)> nudMontoDeuda.Value)
                {
                    if (MessageBox.Show("El monto a pagar es mayor a la Deuda. Desea realizar el Pago?","Atencion", MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        Grabar();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Grabar();
                    MessageBox.Show("El cobro se realizo con exito");
                    RealizoPago = true;
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Pago");
                nudMontoPagar.Select(0, nudMontoPagar.Text.Length);
                nudMontoPagar.Focus();
            }
        }

        private void Grabar()
        {

            var comprobanteNuevo = new CtaCteComprobanteDto
            {
                ClienteId = _cliente.Id,
                EmpleadoId = Identidad.EmpleadoId,
                UsuarioId = Identidad.UsuarioId,
                Fecha = DateTime.Now,
                Descuento = 0,
                SubTotal = nudMontoPagar.Value,
                Total = nudMontoPagar.Value,
                Iva105=0,
                Iva21=0,
                TipoComprobante= TipoComprobante.CuentaCorriente,
                FormasDePagos= new List<FormaPagoDto>(),
                Items = new List<DetalleComprobanteDto>(),
            };

            comprobanteNuevo.FormasDePagos.Add(new FormaPagoCtaCteDto
            {
                ClienteId= _cliente.Id,
                Monto= nudMontoPagar.Value,
                TipoPago= TipoPago.CtaCte,
                Eliminado= false
            });

            comprobanteNuevo.Eliminado = false;

            _cuentaCorrienteServicio.Pagar(comprobanteNuevo);
            
        }
    }
}

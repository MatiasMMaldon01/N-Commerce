using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;

namespace Servicios.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        protected readonly IUnidadDeTrabajo _unidadDeTrabajo;
        protected Dictionary<Type, string> _diccionario;

        public ComprobanteServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _diccionario = new Dictionary<Type, string>();
            InicializadorDiccionario();
        }
        private void InicializadorDiccionario()
        {
            _diccionario.Add(typeof(FacturaDto), "Servicios.Comprobante.Factura");
            _diccionario.Add(typeof(CtaCteComprobanteDto), "Servicios.Comprobante.CuentaCorriente");
        }

        public void AgregarOpcionDiccionario(Type type, string value)
        {
            _diccionario.Add(type, value);
        }

        public virtual long Insertar(ComprobanteDto dto)
        {
            var comprobante = GenericInstance<Comprobante>.InstanciarEntidad(dto, _diccionario);
            return comprobante.Insertar(dto);
        }
    }
}

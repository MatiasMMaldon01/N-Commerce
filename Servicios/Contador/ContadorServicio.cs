using System;
using System.Linq;
using Aplicacion.Constantes;
using Dominio.UnidadDeTrabajo;
using IServicios.Contador;
namespace Servicios.Contador
{
    public class ContadorServicio : IContadorServicio
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ContadorServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public int ObtenerSiguienteNumeroComprobante(TipoComprobante tipoComprobante)
        {
            var resultado = _unidadDeTrabajo.ContadorRepositorio.Obtener(x => x.TipoComprobante == tipoComprobante).FirstOrDefault();

            if (resultado == null)
            {
                throw new Exception("Ocurrio un error al Obtener el numero de Comprobante");
            }
            
            resultado.Valor++;
            
            _unidadDeTrabajo.ContadorRepositorio.Modificar(resultado);
            _unidadDeTrabajo.Commit();
            
            return resultado.Valor;
        }
    }
}

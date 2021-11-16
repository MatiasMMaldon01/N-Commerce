using Aplicacion.Constantes;

namespace IServicios.Contador
{
    public interface IContadorServicio
    {
        int ObtenerSiguienteNumeroComprobante(TipoComprobante tipoComprobante);
    }
}

using IServicio.Configuracion.DTOs;

namespace IServicio.Configuracion
{
    public interface IConfiguracionServicio
    {
        void Grabar(ConfiguracionDto configuracionDto);

        ConfiguracionDto Obtener();

        bool VerificarSiExiste();
    }
}

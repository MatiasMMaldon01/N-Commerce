using Dominio.UnidadDeTrabajo;
using IServicio.Persona;

namespace Servicios.Persona
{
    public class ClienteServicio : PersonaServicio, IClienteServicio
    {
        public ClienteServicio(IUnidadDeTrabajo unidadDeTrabajo) 
            : base(unidadDeTrabajo)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using IServicio.Persona.DTOs;

namespace IServicio.Persona
{
    public interface IPersonaServicio
    {
        long Insertar(PersonaDto persona);

        void Modificar(PersonaDto persona);

        void Eliminar(Type tipoEntidad, long id);

        PersonaDto Obtener(Type tipoEntidad, long id);

        IEnumerable<PersonaDto> Obtener(Type tipoEntidad, string cadenaBuscar, bool mostrarTodos);

        // ==================================================================== //

        void AgregarOpcionDiccionario(Type type, string value);
    }
}

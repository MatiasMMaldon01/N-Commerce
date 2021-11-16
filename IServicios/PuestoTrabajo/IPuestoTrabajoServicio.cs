namespace IServicios.PuestoTrabajo
{
    public interface IPuestoTrabajoServicio : IServicio.Base.IServicio
    {
        bool VerificarSiExiste(string text, long? id);
        //int ObtenerSiguienteNroCodigo();
    }
}

namespace IServicios.Tarjeta
{
    public interface ITarjetaServicio : IServicio.Base.IServicio
    {
       bool VerificarSiExiste(string text, long? id);
    }
}

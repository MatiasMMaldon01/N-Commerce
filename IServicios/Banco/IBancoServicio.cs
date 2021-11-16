namespace IServicios.Banco
{
    public interface IBancoServicio : IServicio.Base.IServicio
    {
        bool VerificarSiExiste(string text, long? id);
    }
}

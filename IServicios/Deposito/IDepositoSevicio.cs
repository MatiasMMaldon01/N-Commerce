namespace IServicio.Deposito
{
    public interface IDepositoSevicio : Base.IServicio
    {
        bool VerificarSiExiste(string text, long? id);
    }
}

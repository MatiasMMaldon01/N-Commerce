namespace IServicios.MotivoBaja
{
    public interface IMotivoBajaServicio: IServicio.Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}

namespace IServicio.ListaPrecio
{
    public interface IListaPrecioServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}

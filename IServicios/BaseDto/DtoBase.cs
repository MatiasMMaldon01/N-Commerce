namespace IServicio.BaseDto
{
    public class DtoBase
    {
        public long Id { get; set; }

        public bool Eliminado { get; set; }

        public string EliminadoStr => Eliminado ? "SI" : "NO";
    }
}

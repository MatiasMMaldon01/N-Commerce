namespace IServicio.Persona.DTOs
{
    public class ClienteDto : PersonaDto
    {
        public long CondicionIvaId { get; set; }

        public string CondicionIva { get; set; }

        public bool ActivarCtaCte { get; set; }
        
        public bool TieneLimiteCompra { get; set; }
        
        public decimal MontoMaximoCtaCte { get; set; }

        public string CtaCteStr => ActivarCtaCte ? "SI" : "NO";

        public string LimiteCompraStr => TieneLimiteCompra ? "SI" : "NO";

        public string MontoMaximoCtaCteStr => MontoMaximoCtaCte.ToString("C");
    }
}

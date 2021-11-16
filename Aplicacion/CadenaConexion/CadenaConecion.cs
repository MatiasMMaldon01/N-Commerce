namespace Aplicacion.CadenaConexion
{
    public static class CadenaConecion
    {
        // Atributos
        private const string Servidor = @"DESKTOP-DH33G6D\SQLEXPRESS"; 
        private const string BaseDatos = @"CommerceDbC4";
        private const string Usuario = @"sa";
        private const string Password = @"pepitogrillo"; 

        // Propiedad
        public static string ObtenerCadenaSql => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"User Id={Usuario}; " +
                                                 $"Password={Password};";

        public static string ObtenerCadenaWin => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"Integrated Security=true;";
    }
}

namespace Aplicacion.Constantes.Clases
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class Password
    {
        private static readonly string ClaveSecreta = "1MonitorFeo@Tiene@BrilloPerfecto";

        public static string PasswordPorDefecto => "M&MPass";

        public static string Encriptar(string cadena)
        {
            var cadenaBytes = Encoding.UTF8.GetBytes(cadena);
            var claveBytes = Encoding.UTF8.GetBytes(ClaveSecreta);

            //creamos un objeto de la clase Rijndael
            var rij = new RijndaelManaged
            {
                //configuramos para que utilize el medo ECB
                Mode = CipherMode.ECB,
                //configuramos para encriptar en 256bit
                BlockSize = 256,
                //declaramos que si necesitas mas bytes agregue ceros
                Padding = PaddingMode.Zeros
            };

            //declaramos un encriptador que use mi clave secreta y un vector de inicializacion aleatorio

            var encriptador = rij.CreateEncryptor(claveBytes, rij.IV);

            //declaramos un stream de memoria para que guarde los datos encriptados a medida que se van calculando
            var memStream = new MemoryStream();

            //declaramos un stream de cibrado para que pueda escribir aqui la cadena a encriptar.
            //Esta clase utiliza el encriptador y el stream de memoria para realizar la encriptacion y para almacenarla
            var cifradoStream = new CryptoStream(memStream, encriptador, CryptoStreamMode.Write);

            //escribo los byte a encriptar. a medida que se va escribiendo se va encripdando la candena
            cifradoStream.Write(cadenaBytes, 0, cadenaBytes.Length);

            //aviso que la encriptacion termino
            cifradoStream.FlushFinalBlock();

            //convertimos los datos encripdatos de la memoria sobre el array
            var cipherTextBytes = memStream.ToArray();

            //cierro los datos creados
            memStream.Close();
            cifradoStream.Close();

            //convierto el resultado en base 64 para que sea legible y devuelvo el resultado
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Desencriptar(string cadena)
        {
            //convierto la candena y la clave en arreglos de bytes para poder usarlas en las funciones de encriptacion
            //en este caso la cadena la convierto usando base 64 que la codificacion usada en el metodo encriptar
            var cadenaBytes = Convert.FromBase64String(cadena);
            var claveBytes = Encoding.UTF8.GetBytes(ClaveSecreta);

            //creo un objeto de la clase rijndael
            var rij = new RijndaelManaged
            {
                //configuro que utilize el modo ECB
                Mode = CipherMode.ECB,
                //configuro para que use encriptacion 256 bit
                BlockSize = 256,
                //declaro que si necesita mas bytes agregue ceros
                Padding = PaddingMode.Zeros
            };

            //declaro un desencriptador que use mi clave secreado y un vector de inicializacion aleatorio
            var desencriptador = rij.CreateDecryptor(claveBytes, rij.IV);

            //declaro un stream de memoria para que guarde losd datos encriptados
            var memStream = new MemoryStream(cadenaBytes);

            //declaro un stream de cifrado para que pueda leer de aqui la cadena a desencriptar. Esta clase utiliza el desencriptador
            //y el stream de memoria para realizar la desencriptacion
            var cifradoStream = new CryptoStream(memStream, desencriptador, CryptoStreamMode.Read);

            //declaro el lector para que lea desde el stream de cibrado a medida que vaya leyendo se ira desencriptando
            var lectorStream = new StreamReader(cifradoStream);

            //leo todos los bytes y los almaceno en una cadena
            var resultado = lectorStream.ReadToEnd();

            //cierro los stream creados
            memStream.Close();
            cifradoStream.Close();
            return resultado;
        }
    }
}

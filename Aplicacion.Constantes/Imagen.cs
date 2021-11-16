using System;
using System.Drawing;
using System.IO;

namespace Aplicacion.Constantes
{
    public static class Imagen
    {
        public static Image ImagenEmpleadoPorDefecto = Properties.RecursoImagenes.Empleado;
        public static Image ImagenProductoPorDefecto = Properties.RecursoImagenes.ProductoPorDefecto;
        public static Image ImgBajaProductoPorDefecto = Properties.RecursoImagenes.BajaProductoPorDefecto;

        public static byte[] ConvertirImagen(Image img)
        {
            var sTemp = Path.GetTempFileName();

            var fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

            fs.Position = 0;

            var imgLength = Convert.ToInt32(fs.Length);

            var bytes = new byte[imgLength];

            fs.Read(bytes, 0, imgLength);

            fs.Close();

            return bytes;
        }

        // Metodo para convertir una bytes en Imagen
        public static Image ConvertirImagen(byte[] bytes)
        {
            if (bytes == null) return null;

            var ms = new MemoryStream(bytes);

            Bitmap bm = null;

            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return bm;
        }
    }
}

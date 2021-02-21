using System.Text;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Operaciones para leer y guardar datos de cache de la base de datos
    /// </summary>
    public static class CacheFunction
    {
        /// <summary>
        /// Convertimos la informacion en bytes para ser guardada al cache en BD
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static byte[] GuardarByte(string dato)
        {
            return Encoding.Unicode.GetBytes(dato);
        }

        /// <summary>
        /// Convertimos la informacion en string para ser leida del cache en BD
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string LeerByte(byte[] dato)
        {
            return Encoding.Unicode.GetString(dato);
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Formatea Fechas al estandar de la aplicacion
    /// </summary>
    public static class FormatoFechaFunction
    {
        /// <summary>
        ///  Formatea Fechas al estandar de la aplicacion
        /// </summary>
        /// <param name="Fecha">fecha a convertir</param>
        /// <param name="Formato">Si se requiere un formato en especifico</param>
        /// <returns>Fecha con el formato deseado</returns>
        public static string FormatoFecha(DateTime Fecha, string Formato = null)
        {
            string fechaConvertida;
            if (Formato == null)
            {
                fechaConvertida = Fecha.ToString("yyyy/MM/dd");
            }
            else
            {
                fechaConvertida = Fecha.ToString(Formato);
            }
            return fechaConvertida;
        }

        /// <summary>
        /// Convierte un fecha string a un DateTime
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public static DateTime ConvertirStringToDate(string Fecha)
        {
            DateTime fechaConvertida = new DateTime();
            if (Fecha != null)
            {
                int anio = Convert.ToInt32(Fecha.Substring(0, 4));
                int mes = Convert.ToInt32(Fecha.Substring(4, 2));
                int dia = Convert.ToInt32(Fecha.Substring(6, 2));
                fechaConvertida = new DateTime(anio, mes, dia);
            }

            return fechaConvertida;
        }

        /// <summary>
        /// Convierte un string  a un string fecha
        /// </summary>
        /// <param name="Fecha"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string ConvertirStringAStringFecha(string Fecha, string separador)
        {
            string fechaConvertida = "";
            if (!String.IsNullOrEmpty(Fecha))
            {
                string anio = Fecha.Substring(0, 4);
                string mes = Fecha.Substring(4, 2);
                string dia = Fecha.Substring(6, 2);
                fechaConvertida = anio + separador + mes + separador + dia;
            }

            return fechaConvertida;
        }


        /// <summary>
        /// Formatea la fecha segun separador que se le envie dentro de un texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="old_"></param>
        /// <param name="new_"></param>
        /// <returns></returns>
        public static String FormatearFechaEnTexto(string texto, string old_, string new_)
        {
            string retorno = "";
            if (!String.IsNullOrEmpty(texto) && texto.Length > 10)
            {
                Match m = Regex.Match(texto, "([0-9]{4}-[0-9]{2}-[0-9]{2})");
                if (m.Success)
                {
                    string num = m.Value;
                    retorno = texto.Replace(num, num.Replace(old_, new_));
                }
                else
                {
                    retorno = texto;
                }

            }
            return retorno;
        }
    }
}

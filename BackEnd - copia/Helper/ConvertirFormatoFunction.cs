using System;
using System.Collections.Generic;
using System.Text;

namespace PlanesFamiliares.Helper
{
    public static class ConvertirFormatoFunction
    {

        static readonly string[] sufijos =
            {
                Enumeraciones.Medida.Bytes.ToString(),
                Enumeraciones.Medida.KB.ToString(),
                Enumeraciones.Medida.MB.ToString(),
                Enumeraciones.Medida.GB.ToString(),
                Enumeraciones.Medida.TB.ToString(),
                Enumeraciones.Medida.PB.ToString(),
            };

        /// <summary>
        /// Devuelve el valor segun el arreglo de sufijos ingresando la cantidad de bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>1.0GB</returns>
        public static string ConvertirBytesASufijo(Int64 bytes)
        {
            int contador = 0;
            decimal numero = (decimal)bytes;
            while (Math.Round(numero / 1024) >= 1)
            {
                numero /= 1024;
                contador++;
            }
            return string.Format("{0:n1}{1}", numero, sufijos[contador]);
        }


        /// <summary>
        /// ConvertirCantidadToBytes
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="medida"></param>
        /// <returns></returns>
        public static Int64 ConvertirCantidadToBytes(Int64 cantidad, string medida)
        {
            Int64 resultado = 0;
            if (medida != null && medida.Length > 0 && cantidad > 0)
            {
                long variable = 1024;
                long result = 1024;
                for (int i = 1; i < sufijos.Length - 1; i++)
                {
                    if (medida.Trim() == sufijos[i])
                    {
                        resultado = result * cantidad;
                    }
                    result = result * variable;
                }
            }
            return resultado;
        }


    }
}

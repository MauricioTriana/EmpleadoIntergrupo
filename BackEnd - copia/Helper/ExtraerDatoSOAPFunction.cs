namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Extrae infomacion de una cadena SOAP dada una llave
    /// </summary>
    public static class ExtraerDatoSoapFunction
    {
        /// <summary>
        /// Extrae infomacion de una cadena SOAP dada una llave
        /// </summary>
        /// <param name="responseSOAP"></param>
        /// <param name="llave"></param>
        /// <returns></returns>
        public static string ExtraerDatoSOAP(string responseSOAP, string llave)
        {
            string data = string.Empty;
            if (!string.IsNullOrEmpty(responseSOAP))
            {
                data = responseSOAP;
            }
            else
            {
                data = "";
            }
            int inicio = data.IndexOf("<" + llave + ">");
            int fin = data.IndexOf("</" + llave + ">");
            if (inicio != -1 && fin != -1)
            {
                data = data.Substring(inicio, fin - inicio).Replace("<" + llave + ">", "");
            }
            else
            {
                data = "";
            }
            return data;
        }
    }
}

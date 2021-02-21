using System.Collections.ObjectModel;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Trae una lista de elementos contenidos en una cadena SOAP dada una llave
    /// </summary>
    public static class ExtraerDatoListSoapFunction
    {
        /// <summary>
        /// Trae una lista de elementos contenidos en una cadena SOAP dada una llave
        /// </summary>
        /// <param name="responseSOAP"></param>
        /// <param name="llave"></param>
        /// <returns></returns>
        public static Collection<string> ExtraerDatoListSOAP(string responseSOAP, string llave)
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

            Collection<string> listaDatos = new Collection<string>();
            bool termino = false;
            string responseSOAPItem = string.Empty;

            int inicio = -1;
            int fin = -1;

            while (!termino)
            {
                inicio = data.IndexOf("<" + llave + ">", inicio + 1);
                fin = data.IndexOf("</" + llave + ">", fin + 1);
                if (inicio != -1 && fin != -1)
                {
                    responseSOAPItem = data.Substring(inicio, fin - inicio).Replace("<" + llave + ">", "");
                    listaDatos.Add(responseSOAPItem);
                }
                else
                {
                    termino = true;
                    data = string.Empty;
                }
            }
            return listaDatos;
        }
    }
}

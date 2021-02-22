using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Net;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Realiza la consulta a un servicio rest con el método GET
    /// </summary>
    public static class ConsultarServicioRestFunction
    {
        /// <summary>
        /// Realiza la consulta a un servicio rest con el método GET
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="url"></param>
        /// <param name="esJson"></param>
        /// <returns></returns>
        public static string ConsultarServicioRest(ILogger logger, Uri url, bool esJson = false)
        {
            if (url != null)
            {
                ServicePointManager.ServerCertificateValidationCallback += (a, b, c, d) => true;
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "text/xml");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    logger.LogInformation("ConsultarServicioRest {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);

                    if (!esJson)
                    {
                        response.Content = response.Content.Replace("\"", "");
                        response.Content = response.Content.Replace(@"\\\", "este no funciona");
                    }
                    return response.Content;
                }
                else
                {                               
                    logger.LogError("ConsultarServicioRest {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);               
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}

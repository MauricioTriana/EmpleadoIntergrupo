using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Net;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Método general para consultar servicios SOAP
    /// </summary>
    public static class ConsultarServicioSoapFunction
    {
        /// <summary>
        /// Método general para consultar servicios SOAP
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="url"></param>
        /// <param name="soap"></param>
        /// <returns></returns>
        public static string ConsultarServicioSoap(ILogger logger, Uri url, string soap, bool retornarErrorContent = false)
        {
            if (url != null)
            {
                ServicePointManager.ServerCertificateValidationCallback += (a, b, c, d) => true;
                soap = soap.Replace(@"\", @"""");
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "text/xml");
                request.AddParameter("undefined", soap, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    logger.LogInformation("ConsultarServicioSoap {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);
                    return response.Content;
                }
                else
                {
                    logger.LogError("ConsultarServicioSoap {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);
                    if (retornarErrorContent)
                    {
                        return response.Content;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            return string.Empty;
        }
    }
}

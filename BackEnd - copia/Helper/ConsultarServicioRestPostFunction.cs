using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

namespace PlanesFamiliares.Helper
{
    public static class ConsultarServicioRestPostFunction
    {
        /// <summary>
        /// Realiza la consulta a un servicio rest con el método POST
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string ConsultarServicioRestPost(ILogger logger, Uri url, JObject body)
        {
            if (url != null)
            {
                ServicePointManager.ServerCertificateValidationCallback += (a, b, c, d) => true;
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    logger.LogInformation("ConsultarServicioRestPost {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);
                    return response.Content;
                }
                else
                {
                    logger.LogError("ConsultarServicioRestPost {@request} {@response} {@url} ".Replace(Environment.NewLine, ""), request, response, url);
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using static Bussiness.Entities.Appsettings;

namespace Bussiness.Services
{
    /// <summary>
    /// Adicionar clases para el manejo de la configuración de la aplicación.
    /// </summary>
    public static class ConfigureService
    {
        /// <summary>
        /// Adicionar clases para el manejo de la configuración de la aplicación.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void AddConfigureService(this IServiceCollection services,IConfiguration Configuration)
        {
            if (Configuration != null)
            {
                services.Configure<Uris>(Configuration.GetSection("Uris"));
                services.Configure<Constantes>(Configuration.GetSection("Constantes"));
            }
        }
    }
}

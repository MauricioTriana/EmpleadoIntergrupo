using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Bussiness.Services
{
    /// <summary>
    /// Manejo de la vesión de la API.
    /// </summary>
    public static class ApiVersioningService
    {
        /// <summary>
        /// Manejo de la vesión de la API.
        /// </summary>
        /// <param name="services"></param>
        public static void AddApiVersioningService(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }
    }
}

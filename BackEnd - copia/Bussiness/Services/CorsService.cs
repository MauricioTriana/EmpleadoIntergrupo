using Microsoft.Extensions.DependencyInjection;
namespace Bussiness.Services
{
    /// <summary>
    /// Configuración de Cors.
    /// </summary>
    public static class CorsService
    {
        /// <summary>
        /// Configuración de Cors.
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}

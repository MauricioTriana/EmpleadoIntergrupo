using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Bussiness.Services
{
    /// <summary>
    /// Configuración de Swagger.
    /// </summary>
    public static class SwaggerGenService
    {
        /// <summary>
        /// Configuración de Swagger.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerGenService(this IServiceCollection services)
        {
            services.AddSwaggerGen(
            options =>
            {
                var provider = services.BuildServiceProvider()
                                    .GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Info()
                        {
                            Title = $"Bussiness {description.ApiVersion}",
                            Version = description.ApiVersion.ToString()
                        });
                }
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "PlanesFamiliares.Bussiness.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}

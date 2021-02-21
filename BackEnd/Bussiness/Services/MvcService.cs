using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Bussiness.Services
{
    /// <summary>
    /// Configuración de MVC.
    /// </summary>
    public static class MvcService
    {
        /// <summary>
        /// Configuración de MVC.
        /// </summary>
        /// <param name="services"></param>
        public static void AddMvcService(this IServiceCollection services)
        {
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Bussiness.Repositories;

namespace Bussiness.Services
{
    /// <summary>
    /// Configuración de los repositorios.
    /// </summary>
    public static class SingletonService
    {
        /// <summary>
        /// Configuración de los repositorios.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSingletonService(this IServiceCollection services)
        {
            services.AddSingleton<IBussinessRepository, BussinessRepository>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}

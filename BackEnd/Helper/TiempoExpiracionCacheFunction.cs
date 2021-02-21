using Microsoft.Extensions.Caching.Memory;
using System;

namespace PlanesFamiliares.Helper
{
    /// <summary>
    /// Método para definir el tiempo que durará el cache de la aplicación.
    /// </summary>
    public static class TiempoExpiracionCacheFunction
    {
        /// <summary>
        /// Método para definir el tiempo que durará el cache de la aplicación.
        /// </summary>
        /// <returns></returns>
        public static MemoryCacheEntryOptions TiempoExpiracionCache(double minutos = 5)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(minutos),
                SlidingExpiration = TimeSpan.FromMinutes(minutos)
            };
            return options;
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PlanesFamiliares.Helper;
using Serilog;

[assembly: System.Runtime.InteropServices.ComVisible(false)]
namespace Bussiness
{
    /// <summary>
    /// Inicio de la aplicación.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Método inicial de la aplicación.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Método para iniciar el host de la aplicación.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((context, config) =>
                {
                    context.Configuration.GetSection("Serilog:WriteTo:0:Args:connectionString").Value = DecryptFunction.Decrypt(context.Configuration.GetSection("Serilog:WriteTo:0:Args:connectionString").Value, "PFA");
                    config.ReadFrom.Configuration(context.Configuration);
                })
                .Build();

    }
}

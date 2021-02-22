using Bussiness.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlanesFamiliares.Helper;

namespace Bussiness
{
    /// <summary>
    /// Clase que permite las configuraciones iniciales de la API
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Interfaz relacionada a la configuracion de la API
        /// </summary>
        public IConfiguration Configuration { get; private set; }
        /// <summary>
        /// Interfaz relacionado al entorno de la API
        /// </summary>
        public IHostingEnvironment HostingEnvironment { get; private set; }

        /// <summary>
        /// Método inicial enla configuración de la API
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            if (env != null)
            {
                this.HostingEnvironment = env;
                var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                Configuration = builder.Build();
            }
        }

        /// <summary>
        /// /Método para adicionar servicios al contenedor.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigureService(this.Configuration);
            services.AddMemoryCache();
            services.AddOptions();
            services.AddCorsService();
            services.AddSingletonService();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerGenService();
            services.AddApiVersioningService();
            services.AddMvcService();

            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = DecryptFunction.Decrypt(Configuration.GetSection("DistributedSqlServerCache").GetSection("ConnectionString").Value, "PFA");
                options.SchemaName = Configuration.GetSection("DistributedSqlServerCache").GetSection("SchemaName").Value;
                options.TableName = Configuration.GetSection("DistributedSqlServerCache").GetSection("TableName").Value;
            });
        }

        /// <summary>
        /// Configuraciones adicionales de la API
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (errorFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500, errorFeature.Error, errorFeature.Error.Message);
                        }
                        await context.Response.WriteAsync("There was an error");
                    });
                });
            }
            string swaggerEndPoint = Configuration.GetSection("SwaggerMap").GetSection("EndPoint").Value;
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerEndPoint, "Proyectos");

            });
            app.UseAuthentication();
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}

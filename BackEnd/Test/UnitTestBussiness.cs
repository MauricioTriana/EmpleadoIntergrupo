using Bussiness;
using Bussiness.Controllers;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;
using static Bussiness.Entities.Appsettings;
using PlanesFamiliares.Test;
using Bussiness.Entities;
using Bussiness.EntityFramework;

namespace Test
{
    public class UnitTestBussiness : IDisposable
    {

        private TestServer _server;
        public HttpClient Client { get; private set; }

        private readonly FluentMockServer bussinessMock;
        BussinessController objControlador;
        UnitTestCache cacheD;
        BussinessRepository bussinessRepository;


        public UnitTestBussiness()
        {
            SetUpClient();
            bussinessMock = FluentMockServer.Start();
            AjustesIniciales();
        }

        protected void GenerarUrlVirtuales(string Path, string Body)
        {

            bussinessMock
                .Given(
                Request.Create()
                .WithPath(Path)
                .UsingAnyMethod()
                )
                .RespondWith(
                Response.Create()
                .WithStatusCode(200)
                .WithBody(Body)
                );
        }

        private void AjustesIniciales(bool conLoger = true)
        {
            cacheD = new UnitTestCache();
            IOptions<Uris> uris = Options.Create<Uris>(new Uris() { Servicios_URI = bussinessMock.Urls[0].ToString() + "/bussiness/" });
            if (conLoger)
            {
                ILogger<BussinessRepository> logger = new Logger<BussinessRepository>(new NullLoggerFactory());
                bussinessRepository = new BussinessRepository(logger, uris, cacheD);
            }
            else
            {
                bussinessRepository = new BussinessRepository(null, uris, cacheD);
            }
            MemoryCache cache = new MemoryCache(new MemoryCacheOptions());
            objControlador = new BussinessController(bussinessRepository, cacheD, cache);
        }

        #region Ejecucion de pruebas unitarias

        [Fact]
        public void ValidaExisteClienteTest()
        {
            string resultado = objControlador.ConsultarDatosEmpleado("1030653317");
            Assert.Contains("Cristian",resultado);
        }

        [Fact]
        public void ListarEmpleadosTest()
        {
            string resultado = objControlador.ListarEmpleados();
            var encontrados = JsonConvert.DeserializeObject<List<Empleado>>(resultado);
            Assert.True(encontrados.Count > 0);
        }

        [Fact]
        public void CrearEmpleadoTest()
        { 
            JObject newEmpleado = new JObject()
                    {
                        { "NombreEmpleado", "pepe"},
                        { "ApellidoEmpleado", "perez"},
                        { "Cargo", "prue"},
                        { "contrasena", "3118365715"},
                        { "DocumentoIdentidad", "A1"}
                    };
            var res = objControlador.CrearEmpleado(newEmpleado);
            Assert.Contains("registro exitoso", res);
        }

        [Fact]
        public void ActualizarEmpleadoTest()
        {
            JObject newEmpleado = new JObject()
                    {
                        { "NombreEmpleado", "pepe"},
                        { "ApellidoEmpleado", "perez"},
                        { "Cargo", "pruebas"},
                        { "contrasena", "3118365715"},
                        { "DocumentoIdentidad", "A1"}
                    };
            var res = objControlador.ActualizarEmpleado(newEmpleado);
            Assert.Contains("Actualizacion exitosa", res);
        }

        [Fact]
        public void LoginEmpleadoExitosoTest()
        {
            var res = objControlador.validarLoginEmpleadoAction("1030653317", "CMT2021");
            Assert.Contains("OK", res);
        }

        [Fact]
        public void LoginEmpleadoNoExitosoTest()
        {
            var res = objControlador.validarLoginEmpleadoAction("ABC", "3118365715");
            Assert.NotEqual("OK", res);
        }
        #endregion
        private void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
            bussinessMock.Stop();
        }
    }
}


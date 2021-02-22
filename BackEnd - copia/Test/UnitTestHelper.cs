using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlanesFamiliares.Helper;
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace PlanesFamiliares.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitTestHelper : IDisposable
    {
        private readonly FluentMockServer helperMock;

        /// <summary>
        /// 
        /// </summary>
        public UnitTestHelper()
        {
            helperMock = FluentMockServer.Start();
        }

        protected void GenerarUrlVirtuales(string Path, string Body)
        {

            helperMock
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

        [Fact]
        public void CompressStringTest()
        {
            string resultado = CompressDecompressFunction.CompressString("Hola Mundo");
            Assert.Contains("CgAAAB+LCAAAAAAAAAvzyM9JVPAtzUvJBwDSbkMiCgAAAA==", resultado);
        }

        [Fact]
        public void CompressStringNoDataTest()
        {
            string resultado = CompressDecompressFunction.CompressString("");
            Assert.Empty(resultado);
        }

        [Fact]
        public void DecompressStringTest()
        {
            string resultado = CompressDecompressFunction.DecompressString("CgAAAB+LCAAAAAAAAAvzyM9JVPAtzUvJBwDSbkMiCgAAAA==");
            Assert.Contains("Hola Mundo", resultado);
        }

        [Fact]
        public void DecompressStringNoDataTest()
        {
            string resultado = CompressDecompressFunction.DecompressString("");
            Assert.Empty(resultado);
        }

        [Fact]
        public void ZipTest()
        {
            byte[] resultado = CompressDecompressFunction.Zip("Hola Mundo");
            Assert.Contains("31", resultado[0].ToString());
        }

        [Fact]
        public void UnzipTest()
        {
            byte[] data = new byte[] { 31, 139, 8, 0, 0, 0, 0, 0, 0, 11, 243, 200, 207, 73, 84, 240, 45, 205, 75, 201, 7, 0, 210, 110, 67, 34, 10, 0, 0, 0 };
            string resultado = CompressDecompressFunction.Unzip(data);
            Assert.Contains("Hola Mundo", resultado);
        }

        [Fact]
        public void CalcularFechaCicloTest()
        {
            string resultado = CalcularFechaCicloFunction.CalcularFechaCiclo(1, "ddMMyyyy");
            Assert.IsType<string>(resultado);
        }

        [Fact]
        public void ConsultarServicioRestFunctionNoDataTest()
        {
            string resultado = ConsultarServicioRestFunction.ConsultarServicioRest(null, null);
            Assert.Contains(string.Empty, resultado);
        }

        [Fact]
        public void ConsultarServicioRestPostFunctionNoDataTest()
        {
            string resultado = ConsultarServicioRestPostFunction.ConsultarServicioRestPost(null, null, null);
            Assert.Contains(string.Empty, resultado);
        }

        [Fact]
        public void ConsultarServicioRestPutFunctionNoDataTest()
        {
            string resultado = ConsultarServicioRestPutFunction.ConsultarServicioRestPut(null, null, null);
            Assert.Contains(string.Empty, resultado);
        }

        [Fact]
        public void ConsultarServicioSoapFunctionNoDataTest()
        {
            string resultado = ConsultarServicioSoapFunction.ConsultarServicioSoap(null, null, null);
            Assert.Contains(string.Empty, resultado);
        }

        [Fact]
        public void ConsultarServicioSoapFunctionNoOKTest()
        {
            Uri url = new Uri(helperMock.Urls[0].ToString() + "/data/TestSOAP");
            ILogger<UnitTestHelper> logger = new Logger<UnitTestHelper>(new NullLoggerFactory());
            string resultado = ConsultarServicioSoapFunction.ConsultarServicioSoap(logger, url, " ");
            Assert.Contains(string.Empty, resultado);
        }

        [Fact]
        public void ConsultarServicioSoapFunctionNoOKRetornoTest()
        {
            Uri url = new Uri(helperMock.Urls[0].ToString() + "/data/TestSOAP");
            ILogger<UnitTestHelper> logger = new Logger<UnitTestHelper>(new NullLoggerFactory());
            string resultado = ConsultarServicioSoapFunction.ConsultarServicioSoap(logger, url, " ", true);
            JObject objResultado = JsonConvert.DeserializeObject<JObject>(resultado);

            Assert.Contains("Status", objResultado.ToString().Substring(6, 6));
        }

        [Fact]
        public void ConvertirBytesASufijoTest()
        {
            string resultado = ConvertirFormatoFunction.ConvertirBytesASufijo(1024);
            Assert.Contains("1.0KB", resultado.Replace(',', '.'));
        }

        [Fact]
        public void ConvertirCantidadToBytesTest()
        {
            long resultado = ConvertirFormatoFunction.ConvertirCantidadToBytes(1024, "GB");
            Assert.Contains("1099511627776", resultado.ToString());
        }

        [Fact]
        public void ConvertirCantidadToBytesNoDataTest()
        {
            long resultado = ConvertirFormatoFunction.ConvertirCantidadToBytes(1024, null);
            Assert.Contains("0", resultado.ToString());
        }

        [Fact]
        public void ConvertirCantidadToBytesNoDataNullTest()
        {
            long resultado = ConvertirFormatoFunction.ConvertirCantidadToBytes(0, null);
            Assert.Contains("0", resultado.ToString());
        }

        [Fact]
        public void DecryptSinTextoTest()
        {
            string resultado = DecryptFunction.Decrypt(null, "A");
            Assert.Null(resultado);
        }

        [Fact]
        public void DecryptSinClaveTest()
        {
            string resultado = DecryptFunction.Decrypt("b+K8cNo20csEyWOFwTxPbw==", null);
            Assert.Contains("1234", resultado);
        }

        [Fact]
        public void EncryptSinTextoTest()
        {
            string resultado = EncryptFunction.Encrypt(null, "A");
            Assert.Null(resultado);
        }

        [Fact]
        public void EncryptSinClaveTest()
        {
            string resultado = EncryptFunction.Encrypt("1234", null);
            Assert.Contains("b+K8cNo20csEyWOFwTxPbw==", resultado);
        }

        //[Fact]
        //public void Encrip()
        //{
        //    string resultado = EncryptFunction.Encrypt("Alta&BajaBnPFA", "TelPFA&Hks");
        //    Assert.Contains("b+K8cNo20csEyWOFwTxPbw==", resultado);
        //}

        [Fact]
        public void ExtraerDatoListSoapFunctionTest()
        {
            Collection<string> resultado = ExtraerDatoListSoapFunction.ExtraerDatoListSOAP(string.Empty, "A");
            Assert.Contains("0", resultado.Count.ToString());
        }

        [Fact]
        public void FormatoFechaFunctionTest()
        {
            string resultado = FormatoFechaFunction.FormatoFecha(DateTime.Now);
            Assert.Contains(DateTime.Now.ToString("yyyy/MM/dd"), resultado);
        }

        [Fact]
        public void GetTipoBonoFunctionTemporalTest()
        {
            string resultado = GetTipoBonoFunction.GetTipoBono(Enumeraciones.TipoBono.Temporal);
            Assert.Contains("IBPG", resultado);
        }

        [Fact]
        public void GetTipoBonoFunctionRenovableTest()
        {
            string resultado = GetTipoBonoFunction.GetTipoBono(Enumeraciones.TipoBono.Renovable);
            Assert.Contains("IDPR", resultado);
        }

        [Fact]
        public void TiempoExpiracionCacheFunctionTest()
        {
            MemoryCacheEntryOptions resultado = TiempoExpiracionCacheFunction.TiempoExpiracionCache();
            Assert.Contains("00:05:00", resultado.SlidingExpiration.ToString());
        }

        [Fact]
        public void FormatearFechaEnTextoTest()
        {
            string resultado = FormatoFechaFunction.FormatearFechaEnTexto("2020-04-03 ", "-", "/");
            Assert.Contains("2020/04/03 ", resultado);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // Method intentionally left empty.
        }
    }
}

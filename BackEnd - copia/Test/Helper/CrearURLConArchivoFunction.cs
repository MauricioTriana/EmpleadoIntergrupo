using System;
using System.IO;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace PlanesFamiliares.Test.Helper
{
    public static class CrearURLConArchivoFunction
    {
        public static void CrearURLConArchivo(string RutaArchivo, string MetodoHTTP, FluentMockServer serviceMock)
        {
            //RUTA DEL MOCK CON EL SOAP DE RESPUESTA
            string rutaMock = AppContext.BaseDirectory + RutaArchivo;

            //SI ENCUENTRA EL ARCHVO PARA EL MOCK, CREAR EL SERVICIO
            if (File.Exists(rutaMock))
            {
                if (MetodoHTTP == "POST")
                {
                    serviceMock
                      .Given(Request.Create().UsingPost())
                      .RespondWith(
                        Response.Create()
                          .WithStatusCode(200)
                          .WithBodyFromFile(rutaMock, true)
                      );
                }
                else if (MetodoHTTP == "GET")
                {
                    serviceMock
                      .Given(Request.Create().UsingGet())
                      .RespondWith(
                        Response.Create()
                          .WithStatusCode(200)
                          .WithBodyFromFile(rutaMock, true)
                      );
                }
            }
        }
    }
}

using System;
using System.IO;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace PlanesFamiliares.Test.Helper
{
    public static class CrearURLSinArchivoFunction
    {
        public static void CrearURLSinArchivo(string Respuesta, string MetodoHTTP, FluentMockServer serviceMock)
        {
            if (MetodoHTTP == "GET")
            {
                serviceMock
                  .Given(Request.Create().UsingGet())
                  .RespondWith(
                    Response.Create()
                      .WithStatusCode(200)
                      .WithBody(Respuesta)
                  );
            }
            else if (MetodoHTTP == "POST")
            {
                serviceMock
                  .Given(Request.Create().UsingPost())
                  .RespondWith(
                    Response.Create()
                      .WithStatusCode(200)
                      .WithBody(Respuesta)
                  );
            }
        }
    }
}

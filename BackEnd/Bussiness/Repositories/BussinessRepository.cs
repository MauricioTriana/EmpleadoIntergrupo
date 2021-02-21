using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlanesFamiliares.Bussiness.Helper;
using PlanesFamiliares.Bussiness.Helper.DataModel;
using System;
using static Bussiness.Entities.Appsettings;

namespace Bussiness.Repositories
{
    /// <summary>
    /// Respositorio para Bussiness
    /// </summary>
    public class BussinessRepository : IBussinessRepository
    {
        private readonly IOptions<Uris> _uris;
        private readonly IDistributedCache cache;
        private readonly ILogger<BussinessRepository> logger;

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="uris"></param>
        /// <param name="cache"></param>
        public BussinessRepository(ILogger<BussinessRepository> logger, IOptions<Uris> uris, IDistributedCache cache)
        {
            _uris = uris;
            this.logger = logger;
            this.cache = cache;
        }


        #region Metodos

        /// <summary>
        /// Consultar el nombre completo de un integrante de la comunidad
        /// </summary>
        /// <param name="cedula">empleado a consultar</param>
        /// <returns>Empleado a consultar</returns>
        public string ConsultarDatosEmpleado( string cedula) => empleadoOperations.ConsultarDatosEmpleado( cedula, _uris, logger, cache);

        /// <summary>
        /// Consultar todos empleados registrados
        /// </summary>
        /// <returns>Empleados a consultar</returns>
        public string ListarEmpleados() => empleadoOperations.ListarEmpleadosAction( _uris, logger, cache);

        /// <summary>
        /// Insertar un empleado en BD
        /// </summary>
        /// <param name="newEmpleado">Objeto de empleado</param>
        /// <returns>mensaje de ejecucion</returns>
        public string CrearEmpleado(JObject newEmpleado) => empleadoOperations.CrearEmpleadoAction(newEmpleado, _uris, logger, cache);

        /// <summary>
        /// Actualizar un empleado en BD
        /// </summary>
        /// <param name="updEmpleado">Objeto de empleado a actualizar</param>
        /// <returns>mensaje de ejecucion</returns>
        public string ActualizarEmpleado(JObject updEmpleado) => empleadoOperations.ActualizarEmpleadoAction(updEmpleado, _uris, logger, cache);

        /// <summary>
        /// Validar login del empleado
        /// </summary>
        /// <param name="identificacion">identificacion del empleado</param>
        /// <param name="contrasena">Contraseña del empleado</param>
        /// <returns>OK si cumple con la validacion de la contraseña</returns>
        public string validarLoginEmpleado(string identificacion, string contrasena) => empleadoOperations.validarLoginEmpleadoAction(identificacion, contrasena, _uris, logger, cache);
        #endregion Metodos




    }
}

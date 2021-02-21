using Bussiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Bussiness.Controllers
{
    /// <summary>
    /// Controlador Bussiness
    /// </summary>
    public class BussinessController : ControllerBase
    {
        #region Propiedades

        private readonly IBussinessRepository _bussinessRepository;
        private readonly IDistributedCache cache;
        private readonly IMemoryCache cacheM;

        #endregion

        #region Constructor

        /// <summary>
        /// Clase constructora.
        /// </summary>
        /// <param name="bussinessRepository"></param>
        /// <param name="cache"></param>
        /// <param name="cacheM"></param>
        public BussinessController(IBussinessRepository bussinessRepository, IDistributedCache cache, IMemoryCache cacheM)
        {
            _bussinessRepository = bussinessRepository;
            this.cache = cache;
            this.cacheM = cacheM;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// consulta la profesion de un empleado
        /// </summary>
        /// <param name="cedula">numero de cedula del empleado</param>
        /// <returns>la profesion del empleado</returns>
        [HttpGet]
        [Route("/api/Bussiness/ConsultarDatosEmpleado/{cedula}")]
        public dynamic ConsultarDatosEmpleado(string cedula)
        {
            if (!String.IsNullOrEmpty(cedula))
            {
                return _bussinessRepository.ConsultarDatosEmpleado(cedula);
            }
            return string.Empty;
        }

        /// <summary>
        /// Empleados a consultar
        /// </summary>
        /// <returns>Empleados a consultar</returns>
        [HttpGet]
        [Route("/api/Bussiness/ListarEmpleados")]
        public dynamic ListarEmpleados()
        {
            return _bussinessRepository.ListarEmpleados();
        }

        /// <summary>
        /// registrar asociacion
        /// </summary>
        /// <param name="newEmpleado">Registro a ingresar</param>
        /// <returns>mensaje con resultado de la operacion</returns>
        [HttpPost]
        [Route("/api/Bussiness/CrearEmpleado")]
        public dynamic CrearEmpleado([FromBody] JObject newEmpleado)
        {
            if (newEmpleado != null)
            {
                return JsonConvert.SerializeObject(_bussinessRepository.CrearEmpleado(newEmpleado), Formatting.None); ;
            }
            return JsonConvert.SerializeObject("No se enviaron todos los datos para el registro", Formatting.None);
        }

        /// <summary>
        /// Actualizar un empleado en BD
        /// </summary>
        /// <param name="updEmpleado">Objeto de empleado a actualizar</param>
        /// <returns>mensaje de ejecucion</returns>
        [HttpPut]
        [Route("/api/Bussiness/ActualizarEmpleado")]
        public dynamic ActualizarEmpleado([FromBody] JObject updEmpleado)
        {
            if (updEmpleado != null)
            {
                return JsonConvert.SerializeObject(_bussinessRepository.ActualizarEmpleado(updEmpleado),Formatting.None);
            }
            return null;
        }


        /// <summary>
        /// Validar login del empleado
        /// </summary>
        /// <param name="identificacion">identificacion del empleado</param>
        /// <param name="contrasena">Contraseña del empleado</param>
        /// <returns>OK si cumple con la validacion de la contraseña</returns>
        [HttpGet]
        [Route("/api/Bussiness/validarLoginEmpleadoAction/{identificacion}/{contrasena}")]
        public dynamic validarLoginEmpleadoAction(string identificacion, string contrasena)
        {
            return JsonConvert.SerializeObject(_bussinessRepository.validarLoginEmpleado(identificacion, contrasena), Formatting.None);
        }
        #endregion
    }
}

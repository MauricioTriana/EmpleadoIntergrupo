using Bussiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlanesFamiliares.Helper;
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

        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ConsultarNombreCompletoIntegante/{sesion}/{NumLinea}")]
        public dynamic ConsultarNombreCompletoIntegrante(string sesion, string NumLinea)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(NumLinea))
            {
                return _bussinessRepository.ConsultarNombreCompletoIntegranteFunction(sesion, NumLinea);
            }
            return string.Empty;
        }
        #endregion
    }
}

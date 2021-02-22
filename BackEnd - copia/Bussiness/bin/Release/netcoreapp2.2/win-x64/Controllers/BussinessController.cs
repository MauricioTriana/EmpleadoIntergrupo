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

        /// <summary>
        ///  Generarcioon de datos ofuscados
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/CrearParametrosOfuscados/{NumeroCelular}")]
        public dynamic CrearParametrosOfuscados(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _bussinessRepository.CrearParametrosOfuscados(NumeroCelular);
            }
            return string.Empty;
        }

        /// <summary>
        /// Desofusca la información enviada a la URL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/PlanesFamiliares/Bussiness/ObtenerParametrosDesofuscados")]
        public dynamic ObtenerParametrosDesofuscados([FromBody] string data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                return _bussinessRepository.ObtenerParametrosDesofuscados(data);
            }
            return string.Empty;
        }

        /// <summary>
        /// Se crea una comunidad y se agrega al Lider.
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="nombreLineaLider"></param>
        /// <param name="capacidadAsignada"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/AgregarLiderComunidadFunction/{sesion}/{nombreLineaLider}/{capacidadAsignada}")]
        public dynamic AgregarLiderComunidadFunction(string sesion, string nombreLineaLider, double capacidadAsignada)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(nombreLineaLider) && Double.TryParse(capacidadAsignada.ToString(), out double price))
            {
                return _bussinessRepository.AgregarLiderComunidad(sesion, nombreLineaLider, capacidadAsignada);
            }
            return string.Empty;
        }

        /// <summary>
        /// Se retorna la información que debe mostrar la ventana de error
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/InformacionPantallaError/{sesion}")]
        public dynamic InformacionPantallaError(string sesion)
        {

            if (!String.IsNullOrEmpty(sesion))
            {
                JObject ObjTitulo = JsonConvert.DeserializeObject<JObject>(CacheFunction.LeerByte(cache.Get(sesion + "-TituloError")));
                JObject ObjSubTitulo = JsonConvert.DeserializeObject<JObject>(CacheFunction.LeerByte(cache.Get(sesion + "-SubTituloError")));

                string titulo;
                try { titulo = ObjTitulo["Mensaje"].ToString(); } catch { throw; };
                string subtitulo;
                try { subtitulo = ObjSubTitulo["Mensaje"].ToString(); } catch { throw; };
                string origen;
                try { origen = CacheFunction.LeerByte(cache.Get(sesion + "-Origen")); } catch { throw; };

                return new JObject
                    {
                        { "TituloError", titulo },
                        { "SubTituloError",subtitulo },
                        { "Origen", origen}
                    };
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerCelularParametro/{sesion}")]
        public dynamic LeerCelularParametro(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return CacheFunction.LeerByte(cache.Get(sesion + "-NumeroCelular"));
            }
            return string.Empty;
        }


        /// <summary>
        /// Guarda en cache el nombre del lider
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="NombreLider"></param>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/GuardarNombreLider/{sesion}/{NombreLider}")]
        public void GuardarNombreLider(string sesion, string NombreLider)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(NombreLider))
            {
                cache.Remove(sesion + "-NombreLider");
                cache.Set(sesion + "-NombreLider", CacheFunction.GuardarByte(NombreLider));
                _bussinessRepository.GuardarMensajesPantallaExito(sesion, true);
            }
        }

        /*
        /// <summary>
        /// Lee el nombre del lider en cache
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerNombreLider/{sesion}")]
        public string LeerNombreLider(string sesion)
        {
          if (!String.IsNullOrEmpty(sesion))
            {
            string nombreLider = CacheFunction.LeerByte(cache.Get(sesion + "-NombreLider"));
            string primerNombreLider = nombreLider.IndexOf(" ") > -1
                  ? nombreLider.Substring(0, nombreLider.IndexOf(" "))
                  : nombreLider;
            return primerNombreLider;
            }
            return string.Empty;
        }*/


        /// <summary>
        /// Guarda en cache los datos del Lider
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="NombreIntegrante"></param>
        /// <param name="CelularIntegrante"></param>
        /// <param name="CapacidadAsignada"></param>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/GuardarDatosIntegrante/{sesion}/{NombreIntegrante}/{CelularIntegrante}/{CapacidadAsignada}")]
        public void GuardarDatosIntegrante(string sesion, string NombreIntegrante, string CelularIntegrante, double CapacidadAsignada)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(NombreIntegrante) && !String.IsNullOrEmpty(CelularIntegrante) && Double.TryParse(CapacidadAsignada.ToString(), out double price))
            {
                cache.Remove(sesion + "-DatosIntegrante-NombreIntegrante");
                cache.Set(sesion + "-DatosIntegrante-NombreIntegrante", CacheFunction.GuardarByte(NombreIntegrante));
                cache.Remove(sesion + "-DatosIntegrante-CelularIntegrante");
                cache.Set(sesion + "-DatosIntegrante-CelularIntegrante", CacheFunction.GuardarByte(CelularIntegrante));
                cache.Remove(sesion + "-DatosIntegrante-CapacidadAsignda");
                cache.Set(sesion + "-DatosIntegrante-CapacidadAsignda", CacheFunction.GuardarByte(CapacidadAsignada.ToString()));
                _bussinessRepository.GuardarMensajesPantallaExito(sesion, false);
            }
        }


        /// <summary>
        /// Lee el nombre del lider en cache
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerDatosIntegrante/{sesion}")]
        public dynamic LeerDatosIntegrante(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                string NombreIntegrante = CacheFunction.LeerByte(cache.Get(sesion + "-DatosIntegrante-NombreIntegrante"));
                string CelularIntegrante = CacheFunction.LeerByte(cache.Get(sesion + "-DatosIntegrante-CelularIntegrante"));

                string primerNombreIntegrante = NombreIntegrante.IndexOf(" ") > -1
                ? NombreIntegrante.Substring(0, NombreIntegrante.IndexOf(" "))
                : NombreIntegrante;


                return new JObject
                    {
                        { "nombre", primerNombreIntegrante},
                        { "celular", CelularIntegrante}
                    };
            }
            return null;
        }

        /// <summary>
        /// Genera un código aleatorio para realizar una posterior verificación
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/GenerarCodigoVerificacion/{sesion}")]
        public string GenerarCodigoVerificacion(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.GenerarCodigoVerificacion(sesion);
            }
            return string.Empty;
        }
        /// <summary>
        /// Verifica Token  para insercion de miembro a la comunidad
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ValidarCodigoVerificacion/{sesion}/{Codigo}")]
        public bool ValidarCodigoVerificacion(string sesion, string Codigo)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ValidarCodigoVerificacion(sesion, Codigo);
            }
            return false;
        }

        /// <summary>
        /// Carga las variables de sesion en cache
        /// </summary>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ConsultarVariableSesPospago/")]
        public dynamic ConsultarVariableSesPospago()
        {
            return _bussinessRepository.ConsultarVariableSesPospago();
        }


        /// <summary>
        /// Lee la información de los integrantes de la comunidad
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerDatosComunidad/{sesion}")]
        public dynamic LeerDatosComunidad(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.LeerDataComunidad(sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene los datos a mostrar en la pantalla de Resumen
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ResumenComunidad/{sesion}")]
        public dynamic ResumenComunidad(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                if (!cacheM.TryGetValue<JObject>(sesion + "-ResumenComunidad", out JObject valorRetorno))
                {
                    valorRetorno = _bussinessRepository.ResumenComunidad(sesion);
                    cacheM.Set(sesion + "-ResumenComunidad", CacheFunction.GuardarByte(valorRetorno.ToString()));
                }
                return valorRetorno;
            }
            return string.Empty;
        }


        /// <summary>
        /// Redireccionar ingreso de la aplicacion
        /// </summary>
        /// <param name="NumeroCelular">numero de celular a validar</param>
        /// <param name="sesion">Sesion en curso</param>
        /// <returns>Direccion de pantalla a presentar</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/DireccionarIngreso/{NumeroCelular}/{sesion}")]
        public dynamic DireccionarIngreso(string NumeroCelular, string sesion)
        {
            if (!String.IsNullOrEmpty(NumeroCelular) && !String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.DireccionarIngreso(NumeroCelular, sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validaciones que se realizan despues de desofucar el parámetro de entrada y antes de iniciar el flujo.
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ValidacionesIniciales/{sesion}")]
        public dynamic ValidacionesIniciales(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ValidacionesIniciales(sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Realiza las validaciones correspondientes a una línea
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ValidacionesIntegrantesComunidad/{sesion}")]
        public bool ValidacionesIntegrantesComunidad(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ValidacionesIntegrantesComunidad(sesion);
            }
            return false;
        }

        /// <summary>
        /// Se consulta la capacidad de una línea determinada.
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ConsultarCapacidad/{sesion}")]
        public dynamic ConsultarCapacidad(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ConsultarCapacidad(sesion);
            }
            return string.Empty;
        }


        /// <summary>
        /// Lee de cache los mensajes de texto para las pantallas de exito al agregar comunidad y al agregar integrante
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerMensajesPantallaExito")]
        public dynamic LeerMensajesPantallaExito()
        {

            JObject ObjTitulo = JsonConvert.DeserializeObject<JObject>(CacheFunction.LeerByte(cache.Get("exito-TituloError")));
            JObject ObjSubTitulo = JsonConvert.DeserializeObject<JObject>(CacheFunction.LeerByte(cache.Get("exito-SubTituloError")));
            string origen = CacheFunction.LeerByte(cache.Get("exito-Origen"));

            return new JObject
                    {
                        { "TituloError", ObjTitulo["Mensaje"].ToString()},
                        { "SubTituloError", ObjSubTitulo["Mensaje"].ToString()},
                        { "Origen", origen}
                    };
        }


        /// <summary>
        /// Se encarga de realizar la comparticion de datos
        /// </summary>
        /// /// <param name="sesion"></param>
        /// <param name="celularOrigen"></param>
        /// <param name="celularDestino"></param>
        /// <param name="gb"></param>
        /// <param name="celularPadre"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/CompartirDatos/{sesion}/{celularOrigen}/{celularDestino}/{gb}/{celularPadre}")]
        public dynamic CompartirDatos(string sesion, string celularOrigen, string celularDestino, string gb, string celularPadre)
        {
            Int64 intento = 0;
            if (!String.IsNullOrEmpty(sesion)
                && !String.IsNullOrEmpty(celularOrigen)
                 && Int64.TryParse(celularOrigen, out intento)
                 && celularOrigen.Length == 10
                 && !String.IsNullOrEmpty(celularDestino)
                 && Int64.TryParse(celularDestino, out intento)
                 && celularDestino.Length == 10
                 && Int64.TryParse(gb, out intento)
                 && !String.IsNullOrEmpty(celularPadre)
                 && Int64.TryParse(celularPadre, out intento)
                 && celularPadre.Length == 10)
            {
                return _bussinessRepository.CompartirDatos(sesion, celularOrigen, celularDestino, gb, celularPadre);
            }

            return string.Empty;
        }

        /// <summary>
        /// Se encarga de realizar el cambio de plan de la linea hija
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="celularPadre"></param>
        /// <param name="celularHijo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/CambiarPlanFamiliarHijo/{sesion}/{celularPadre}/{celularHijo}")]
        public dynamic CambiarPlanFamiliar(string sesion, string celularPadre, string celularHijo)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(celularPadre) && !String.IsNullOrEmpty(celularHijo))
            {
                return _bussinessRepository.CambiarPlanFamiliarHijo(sesion, celularPadre, celularHijo);
            }
            return string.Empty;
        }


        /// <summary>
        /// Retorna la informacion del resumen de un itegrante
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ResumenIntegrante/{sesion}")]
        public dynamic ResumenIntegrante(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ResumenIntegrante(sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Realiza la Activacion de la comunidad  en Planes familiares
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ActivacionPlanFamiliar/{sesion}")]
        public bool ActivacionPlanFamiliar(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ActivacionPlanFamiliar(sesion);
            }
            return false;
        }

        /// <summary>
        /// Pocesar la distribucion de gigas de una comunidad
        /// </summary>
        /// <param name="dataDistribucion">datos a distribuir</param>
        /// <returns>True si pudo distribuir correctamente todos los datos</returns>
        [HttpPost]
        [Route("/api/PlanesFamiliares/Bussiness/ProcesarDistibucionGigas/")]
        public dynamic ProcesarDistibucionGigas([FromBody]string dataDistribucion)
        {
            if (!String.IsNullOrEmpty(dataDistribucion))
            {
                return _bussinessRepository.ProcesarDistibucionGigas(dataDistribucion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validaciones para suspender integrante cuando se va a eliminar
        /// </summary>
        /// <param name="NumeroCelular">Numero de linea a validar</param>
        /// <param name="sesion">Sesion en curso</param>
        /// <returns>True si cumple con las validaciones</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ValidacionesSuspencionBaja/{NumeroCelular}/{sesion}")]
        public dynamic ValidacionesSuspencionBaja(string NumeroCelular, string sesion)
        {
            if (!String.IsNullOrEmpty(NumeroCelular) && !String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ValidacionesSuspencionBaja(NumeroCelular, sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Leer la distribucion de gigas aplicada 
        /// </summary>
        /// <param name="distribucion">Cadena de distribucion</param>
        /// <returns>Json con la distribucion</returns>
        [HttpPost]
        [Route("/api/PlanesFamiliares/Bussiness/LeerDistribucionGigas")]
        public dynamic LeerDistribucionGigas([FromBody] JArray distribucion)
        {
            if (distribucion != null)
            {
                return _bussinessRepository.LeerDistribucionGigas(distribucion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Lee el nombre del lider en cache
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerNumeroLider/{sesion}")]
        public string LeerNumeroLider(string sesion)
        {
            string numeroLider = string.Empty;
            if (!String.IsNullOrEmpty(sesion))
            {
                numeroLider = CacheFunction.LeerByte(cache.Get(sesion + "-NumeroLider"));
            }
            return numeroLider;
        }



        /// <summary>
        /// Obtener datos de integrante para experiencia
        /// </summary>
        /// <param name="sesion">Codigo de sesion en curso</param>
        /// <returns>Data de la linea </returns>

        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerNombreLider/{sesion}")]
        public dynamic LeerNombreLider(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.LeerNombreLider(sesion);
            }
            return string.Empty;
        }


        /// <summary>
        /// Lee la información de los integrantes de la comunidad
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerDataAllComunidad/{sesion}")]
        public dynamic LeerDataAllComunidad(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.LeerDataAllComunidad(sesion);
            }
            return string.Empty;
        }



        /// <summary>
        /// Eliminar Integrante de la comunidad y enviar SMS
        /// </summary>
        /// <param name="numeroCelular">Numero Celular linea a eliminar</param>
        /// <param name="sesion">Sesion en curso</param>
        /// <returns>True si elimino y envio correctamente el SMS</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ProcesoEliminarIntegrante/{numeroCelular}/{sesion}")]
        public dynamic ProcesoEliminarIntegrante(string numeroCelular, string sesion)
        {
            if (!String.IsNullOrEmpty(numeroCelular) && !String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ProcesoEliminarIntegrante(numeroCelular, sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Leer parametros genericos
        /// </summary>
        /// <param name="llaveParametro"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/LeerParametro/{llaveParametro}")]
        public dynamic LeerParametro(string llaveParametro)
        {
            if (!String.IsNullOrEmpty(llaveParametro))
            {
                return _bussinessRepository.LeerParametro(llaveParametro);
            }
            return string.Empty;
        }

        /// <summary>
        /// Retorna mensaje de usuario en especifico con posibilidad de agragar texto personalizado
        /// </summary>
        /// <param name="codMensaje">Codigo Mensaje</param>
        /// <param name="textoAdicional">Texto Adicional</param>
        /// <returns></returns>

        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ConsultarMensajesPersonalizado/{codMensaje}/{textoAdicional}")]
        public dynamic ConsultarMensajesPersonalizado(string codMensaje, string textoAdicional)
        {
            if (!String.IsNullOrEmpty(codMensaje) && !String.IsNullOrEmpty(textoAdicional))
            {
                return _bussinessRepository.ConsultarMensajesPersonalizado(codMensaje, textoAdicional);
            }
            return string.Empty;
        }
        /// <summary>
        /// Actualizar el nombre de un intergante de la comunidad
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="NumLinea">Numero de linea a editar</param>
        /// <param name="NomLinea">Nombre nuevo del integrante</param>
        /// <returns>Mensaje de ejecucion correcta</returns>

        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ActualizarNomIntegranteComunidad/{sesion}/{NumLinea}/{NomLinea}")]
        public dynamic ActualizarNomIntegranteComunidad(string sesion, string NumLinea, string NomLinea)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(NumLinea) && !String.IsNullOrEmpty(NomLinea))
            {
                return _bussinessRepository.ActualizarNomIntegranteComunidad(sesion, NumLinea, NomLinea);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtener data de experiencia de comunidad
        /// </summary>
        /// <param name="numeroLinea">Numero de linea a validar</param>
        /// <returns>data de la comunidad</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ObtenerDataExperiencia/{numeroLinea}")]
        public dynamic ObtenerDataExperiencia(string numeroLinea)
        {
            if (!String.IsNullOrEmpty(numeroLinea))
            {
                return _bussinessRepository.ObtenerDataExperiencia(numeroLinea);
            }
            return string.Empty;
        }

        /// <summary>
        /// ActualizarEstadoIntegranteComunidad
        /// </summary>
        /// <param name="NumLinea"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ActualizarEstadoIntegranteComunidad/{NumLinea}/{Estado}")]
        public dynamic ActualizarEstadoIntegranteComunidad(string NumLinea, string Estado)
        {
            if (!String.IsNullOrEmpty(NumLinea) && !String.IsNullOrEmpty(Estado))
            {
                return _bussinessRepository.ActualizarEstadoIntegranteComunidad(NumLinea, Estado);
            }
            return string.Empty;
        }


        /// <summary>
        /// Obtener data de soporte de comunidad
        /// </summary>
        /// <param name="numeroLinea">Numero de linea a validar</param>
        /// <returns>data de la comunidad</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ObtenerDataSoporte/{numeroLinea}")]
        public dynamic ObtenerDataSoporte(string numeroLinea)
        {
            if (!String.IsNullOrEmpty(numeroLinea))
            {
                return _bussinessRepository.ObtenerDataSoporte(numeroLinea);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtener datos para distribucion
        /// </summary>
        /// <param name="numeroLinea"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ObtenerInformacionCompartir/{numeroLinea}")]
        public dynamic ObtenerInformacionCompartir(string numeroLinea)
        {
            if (!String.IsNullOrEmpty(numeroLinea))
            {
                return _bussinessRepository.ObtenerInformacionCompartir(numeroLinea);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar email abonado
        /// </summary>
        /// <param name="sesion">Numero de sesion</param>
        /// <returns>Correo del abonado si lo tiene</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/ConsultarEmailAbonado/{sesion}")]
        public dynamic ConsultarEmailAbonado(string sesion)
        {
            if (!String.IsNullOrEmpty(sesion))
            {
                return _bussinessRepository.ConsultarEmailAbonado(sesion);
            }
            return string.Empty;
        }

        /// <summary>
        /// Cargar parametros en cache
        /// </summary>
        /// <param name="sesion">Sesion en curso</param>
        /// <param name="nomCacheParam">Nombre de parametro de cache</param>
        /// <param name="valCacheParam">Valor del parametro de cache</param>
        /// <returns>True si carga exitosamente parametro de cache</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Bussiness/AddCacheParam/{sesion}/{nomCacheParam}/{valCacheParam}")]
        public dynamic AddCacheParam(string sesion, string nomCacheParam, string valCacheParam)
        {
            if (!String.IsNullOrEmpty(sesion) && !String.IsNullOrEmpty(nomCacheParam) && !String.IsNullOrEmpty(valCacheParam))
            {
                return _bussinessRepository.AddCacheParam(sesion, nomCacheParam, valCacheParam);
            }
            return false;
        }

        /// <summary>
        /// Consultar el nombre de un integrante de la comunidad
        /// </summary>
        /// <param name="sesion"></param>
        /// <param name="NumLinea">Numero de linea a editar</param>
        /// <returns>Mensaje de ejecucion correcta</returns>

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

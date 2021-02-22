using Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using Services.Entities;

namespace Services.Controllers
{
    /// <summary>
    /// Controlador Bussiness
    /// </summary>
    public class ServicesController : ControllerBase
    {
        #region Propiedades

        private readonly IServicesRepository _servicesRepository;
        private readonly IMemoryCache cache;

        #endregion

        #region Constructor

        /// <summary>
        /// Clase constructora.
        /// </summary>
        /// <param name="servicesRepository"></param>
        /// <param name="cache"></param>
        public ServicesController(IServicesRepository servicesRepository, IMemoryCache cache)
        {
            _servicesRepository = servicesRepository;
            this.cache = cache;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/GetBoltonsDetailsServicio/{NumeroCelular}")]
        public dynamic GetBoltonsDetailsServicio(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _servicesRepository.GetBoltonsDetailsServicio(NumeroCelular);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si un cliente cumple con el estado AAA dentro de FS
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono a validar</param>
        /// <returns>Si el estado es AAA retorna verdadero</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaClienteEstado/{primaryTelephoneNumber}")]
        public dynamic ValidaClienteEstado(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaClienteEstado(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar la oferta primaria de la linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono a validar</param>
        /// <returns>Codigo de la oferta primaria</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/consultaOfertaCliente/{primaryTelephoneNumber}")]
        public dynamic consultaOfertaCliente(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.consultaOfertaCliente(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si la linea cumple con la antiguedad minima para el registro del plan familiar
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono a validar</param>
        /// <returns>Si cumple con antiguedad retorna verdadero</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaAntiguedadLinea/{primaryTelephoneNumber}")]
        public dynamic ValidaAntiguedadLinea(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaAntiguedadLinea(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si la linea es pospago
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de linea a validar</param>
        /// <returns>Si la linea es pospago retorna verdadero</returns>       
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidarLineaPospago/{primaryTelephoneNumber}")]
        public dynamic ValidarLineaPospago(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidarLineaPospago(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si la linea es prepago
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de linea a validar</param>
        /// <returns>Si la linea es pospago retorna verdadero</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaLineaPrepago/{primaryTelephoneNumber}")]
        public dynamic ValidaLineaPrepago(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.validaLineaPrepago(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar el ciclo de plan
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de linea a validar</param>
        /// <returns>el ciclo de plan que tiene una linea</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/consultarCiclo/{primaryTelephoneNumber}")]
        public dynamic consultarCiclo(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.consultarCiclo(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Retornar datos de cliente
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono</param>
        /// <returns>Datos basicos de un cliente en tipo Json</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultaDatosAbonado/{primaryTelephoneNumber}")]
        public dynamic ConsultaDatosAbonado(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultaDatosAbonado(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/QueryPurchasedOfferingServicio/{NumeroCelular}")]
        public dynamic QueryPurchasedOfferingServicio(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _servicesRepository.QueryPurchasedOfferingServicio(NumeroCelular);
            }
            return string.Empty;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTypeNationalIdentityCardIdentification"></param>
        /// <param name="cardNumberIdentity"></param>
        /// <param name="issueDateQPSInfo"></param>
        /// <param name="lastNameCustomer"></param>
        /// <param name="browserUserAgent"></param>
        /// <param name="valueParameter"></param>
        /// <param name="paymentPlanIdInfo"></param>
        /// <param name="evaluationTypeInfo"></param>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/QueryPreScoreServicio/{idTypeNationalIdentityCardIdentification}" +
            "/{cardNumberIdentity}" +
            "/{issueDateQPSInfo}" +
            "/{lastNameCustomer}" +
            "/{browserUserAgent}" +
            "/{valueParameter}" +
            "/{paymentPlanIdInfo}" +
            "/{evaluationTypeInfo}" +
            "/{primaryTelephoneNumber}")]
        public dynamic QueryPreScoreServicio(string idTypeNationalIdentityCardIdentification,
            string cardNumberIdentity,
            string issueDateQPSInfo,
            string lastNameCustomer,
            string browserUserAgent,
            string valueParameter,
            string paymentPlanIdInfo,
            string evaluationTypeInfo,
            string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(idTypeNationalIdentityCardIdentification)
                && !String.IsNullOrEmpty(cardNumberIdentity)
                && !String.IsNullOrEmpty(issueDateQPSInfo)
                && !String.IsNullOrEmpty(lastNameCustomer)
                && !String.IsNullOrEmpty(browserUserAgent)
                && !String.IsNullOrEmpty(valueParameter)
                && !String.IsNullOrEmpty(paymentPlanIdInfo)
                && !String.IsNullOrEmpty(evaluationTypeInfo)
                && !String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.QueryPreScoreServicio
                (
                    idTypeNationalIdentityCardIdentification,
                     cardNumberIdentity,
                     issueDateQPSInfo,
                     lastNameCustomer,
                     browserUserAgent,
                     valueParameter,
                     paymentPlanIdInfo,
                     evaluationTypeInfo,
                     primaryTelephoneNumber
                );
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si un cliente se encuentra en Fraude
        /// </summary>
        /// <param name="idTypeNationalIdentityCardIdentification">Tipo de identificacion</param>
        /// <param name="cardNrNationalIdentityCardIdentification">Numero de identificacion</param>
        /// <returns> Booleano determinando si el cliente esta en fraude</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaClienteEnFraude/{idTypeNationalIdentityCardIdentification}/{cardNrNationalIdentityCardIdentification}")]
        public dynamic ValidaClienteEnFraude(string idTypeNationalIdentityCardIdentification, string cardNrNationalIdentityCardIdentification)
        {
            if (!String.IsNullOrEmpty(idTypeNationalIdentityCardIdentification) && !String.IsNullOrEmpty(cardNrNationalIdentityCardIdentification))
            {
                return _servicesRepository.ValidaClienteEnFraude(idTypeNationalIdentityCardIdentification, cardNrNationalIdentityCardIdentification);
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/QueryLongSegmentationServicio/{NumeroCelular}")]
        public dynamic QueryLongSegmentationServicio(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _servicesRepository.QueryLongSegmentationServicio(NumeroCelular);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene el codigo de la cuenta de una Linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de linea a consultar</param>
        /// <returns>Codigo de la cuenta </returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/obtenerCodCuenta/{primaryTelephoneNumber}")]
        public dynamic obtenerCodCuenta(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.obtenerCodCuenta(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Valida si el cliente tiene la linea con baja programada
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si el cliente tiene una baja programada</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneBajaProgramada/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneBajaProgramada(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneBajaProgramada(primaryTelephoneNumber);
            }
            return false;
        }

        /// <summary>
        ///  Valida si la linea tiene programada una migracipon POS a PRE
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si tiene una migracion programada</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneMigracionPosPre/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneMigracionPosPre(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneMigracionPosPre(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Valida si la linea tiene programada una migracipon PRE a POS
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si tiene una migracion programada</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneMigracionPrePos/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneMigracionPrePos(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneMigracionPrePos(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Valida si el cliente tiene un cambio de titularidad en la linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si el cliente tiene cambio de titularidad programado</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneCambioTitularidad/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneCambioTitularidad(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneCambioTitularidad(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Valida si el cliente tiene un cambio de sim sobre la linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si el cliente tiene cambio de sim activo</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneCambioSim/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneCambioSim(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneCambioSim(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Valida si el cliente tiene un cambio de plan en curso
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de line a validar</param>
        /// <returns>True si el cliente tiene un cambio de plan en curso</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaTieneCambioPlan/{primaryTelephoneNumber}")]
        public dynamic ValidaTieneCambioPlan(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaTieneCambioPlan(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Envio de mensajes SMS
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero a enviar mensaje</param>
        /// <param name="mensaje">Llave del mensaje de texto</param>
        /// <returns>Exito dle mensaje</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/escribirSMS/{primaryTelephoneNumber}/{mensaje}")]
        public dynamic escribirSMS(string primaryTelephoneNumber, string mensaje)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber) && !String.IsNullOrEmpty(mensaje))
            {
                return _servicesRepository.escribirSMS(primaryTelephoneNumber, mensaje);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar la fecha de activacion de linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero a validar</param>
        /// <returns>Fecha de activacion de la linea</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarFechaActivacion/{primaryTelephoneNumber}")]
        public dynamic ConsultarFechaActivacion(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarFechaActivacionLinea(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Validar si un cliente esta en estado suspendido dentro de FS
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono a validar</param>
        /// <returns>Si el estado es suspendido retorna verdadero</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaEstadoSuspendido/{primaryTelephoneNumber}")]
        public dynamic ValidaEstadoSuspendido(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaEstadoSuspendido(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtener los valores de Capacidad y Disponibilidad de una linea
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarCapacidad/{primaryTelephoneNumber}")]
        public dynamic ConsultarCapacidad(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarCapacidad(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar Segmento
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarSegmento/{NumeroCelular}")]
        public dynamic ConsultarSegmento(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _servicesRepository.ConsultarSegmentoLinea(NumeroCelular);
            }
            return string.Empty;
        }

        /// <summary>
        /// Cambio Plan Oferta
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <param name="oferta"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/CambioPlanOferta/{NumeroCelular}/{oferta}")]
        public dynamic CambioPlanOferta(string NumeroCelular, string oferta)
        {
            if (!String.IsNullOrEmpty(NumeroCelular) && !String.IsNullOrEmpty(oferta))
            {
                return _servicesRepository.CambioPlanOferta(NumeroCelular, oferta);
            }
            return string.Empty;
        }

        /// <summary>
        /// Realiza la Distribucion de gigas en linea Origen y Destino 
        /// </summary>
        /// <param name="distribucionGigas"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/PlanesFamiliares/Services/CompartirGigas")]
        public dynamic CompartirGigas([FromBody] JObject distribucionGigas)
        {
            if (distribucionGigas != null)
            {
                return _servicesRepository.DistribuirGigas(distribucionGigas);
            }
            return string.Empty;
        }

        /// <summary>
        /// ConsultarQueryOrder
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarQueryOrder/{primaryTelephoneNumber}")]
        public dynamic ConsultarQueryOrder(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarQueryOrder(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Valida si una linea prepago pertenece al lider de la comunidad
        /// </summary>
        /// <param name="parentTelephoneNumber">Numero de linea padre a validar</param>
        /// <param name="prepaidTelephoneNumber">Numero de linea prepago a validar</param>
        /// <returns>True si pertenecen al lider de comunidads</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaEsMismoClienteLineaPrepago/{parentTelephoneNumber}/{prepaidTelephoneNumber}")]
        public dynamic ValidaEsMismoClienteLineaPrepago(string parentTelephoneNumber, string prepaidTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(parentTelephoneNumber) && !string.IsNullOrEmpty(prepaidTelephoneNumber))
            {
                return _servicesRepository.ValidaEsMismoClienteLineaPrepago(parentTelephoneNumber, prepaidTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Valida la cantidad de lineas pospago
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaLineasPosPagoCliente/{primaryTelephoneNumber}")]
        public dynamic ValidaLineasPosPagoCliente(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaLineasPosPagoCliente(primaryTelephoneNumber);
            }
            return string.Empty;
        }


        /// <summary>
        /// Validacion de Cartera y Fraude
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ValidaListasNegrasCarteraFraude/{primaryTelephoneNumber}")]
        public dynamic ValidaListasNegrasCarteraFraude(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ValidaListasNegrasCarteraFraude(primaryTelephoneNumber);
            }
            return string.Empty;
        }


        /// <summary>
        /// Procesar Baja
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ProcesarBaja/{primaryTelephoneNumber}")]
        public dynamic ProcesarBaja(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ProcesarBaja(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// EnviarSMSService
        /// </summary>
        /// <param name="enviarSMSRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/PlanesFamiliares/Services/EnviarSMS/")]
        public dynamic EnviarSMSService([FromBody] JObject enviarSMSRequest)
        {
            if (enviarSMSRequest != null)
            {
                return _servicesRepository.EnviarSMSService(enviarSMSRequest);
            }
            return string.Empty;
        }


        /// <summary>
        /// Migrar Plan Oferta de Pos a Pre y de Pre a Pos
        /// </summary>
        /// <param name="numeroCelular"></param>
        /// <param name="oferta"></param>
        /// <param name="emailAbonado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/MigrarPlanOferta/{numeroCelular}/{oferta}/{emailAbonado}")]
        public dynamic MigrarPlanOferta(string numeroCelular, string oferta, string emailAbonado)
        {
            if (!String.IsNullOrEmpty(numeroCelular) && !String.IsNullOrEmpty(oferta) && emailAbonado != null)
            {
                return _servicesRepository.MigrarPlanOferta(numeroCelular, oferta, emailAbonado);
            }
            return string.Empty;
        }

        /// <summary>
        /// GetBoltonsDetailsFiltro
        /// </summary>
        /// <param name="NumeroCelular"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/GetBoltonsDetailsFiltro/{NumeroCelular}")]
        public dynamic GetBoltonsDetailsFiltro(string NumeroCelular)
        {
            if (!String.IsNullOrEmpty(NumeroCelular))
            {
                return _servicesRepository.GetBoltonsDetailsFiltroServicio(NumeroCelular);
            }
            return string.Empty;
        }

        /// <summary>
        /// ConsultarCapacidadBolton
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarCapacidadBolton/{primaryTelephoneNumber}")]
        public dynamic ConsultarCapacidadBolton(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarCapacidadBolton(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// consulta el email de una persona en GetCustomer
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de linea a validar</param>
        /// <returns>Email de la linea consultada</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarEmailGetCustomer/{primaryTelephoneNumber}")]
        public dynamic ConsultarEmailGetCustomer(string primaryTelephoneNumber)
        {
            if (!string.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarEmailGetCustomer(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consulta el email de cuenta
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de linea a validar</param>
        /// <returns>Correo de la cuenta</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarEmailGetAccount/{primaryTelephoneNumber}")]
        public dynamic ConsultarEmailGetAccount(string primaryTelephoneNumber)
        {
            if (!string.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarEmailGetAccount(primaryTelephoneNumber);
            }
            return string.Empty;
        }


        /// <summary>
        /// Actualizar ciclo de un abonado
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono abonado</param>
        /// <param name="ciclo">ciclo a aplicar el cambio</param>
        /// <returns>True si actualiza ciclo</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ActualizarCicloAbonado/{primaryTelephoneNumber}/{ciclo}")]
        public dynamic ActualizarCicloAbonado(string primaryTelephoneNumber, string ciclo)
        {
            if (!string.IsNullOrEmpty(primaryTelephoneNumber) && !String.IsNullOrEmpty(ciclo))
            {
                return _servicesRepository.ActualizarCicloAbonado(primaryTelephoneNumber, ciclo);
            }
            return string.Empty;
        }

        /// <summary>
        /// consultar el detalle de fraude de una linea 
        /// </summary>
        /// <param name="primaryTelephoneNumber">numero de linea a consultar</param>
        /// <returns>Detalle de error</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultaDetalleFraude/{primaryTelephoneNumber}")]
        public dynamic ConsultaDetalleFraude(string primaryTelephoneNumber)
        {
            if (!string.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultaDetalleFraude(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consulta en que estado se encuentra una orden.
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <param name="IdOrden"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarEstadoOrden/{primaryTelephoneNumber}/{IdOrden}")]
        public dynamic ConsultarEstadoOrden(string primaryTelephoneNumber, string IdOrden)
        {
            if (!string.IsNullOrEmpty(primaryTelephoneNumber) && !string.IsNullOrEmpty(IdOrden))
            {
                return _servicesRepository.ConsultarEstadoOrden(primaryTelephoneNumber, IdOrden);
            }
            return string.Empty;
        }

        /// <summary>
        /// Consultar Estado y su detalle de una linea
        /// </summary>
        /// <param name="primaryTelephoneNumber">Numero de telefono a validar</param>
        /// <returns>Si el estado es suspendido retorna verdadero</returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/ConsultarEstadoLinea/{primaryTelephoneNumber}")]
        public dynamic ConsultarEstadoLinea(string primaryTelephoneNumber)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber))
            {
                return _servicesRepository.ConsultarEstadoLinea(primaryTelephoneNumber);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Servicio que baja los bonos de altamira para una linea 
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <param name="bono"></param>
        /// <param name="llave"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/BajarBono/{primaryTelephoneNumber}/{bono}/{llave}")]
        public dynamic UnsubscribeBoltonServicio(string primaryTelephoneNumber, string bono, string llave)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber) && !String.IsNullOrEmpty(bono) && !String.IsNullOrEmpty(llave))
            {
                return _servicesRepository.UnsubscribeBoltonServicio(primaryTelephoneNumber, bono, llave);
            }
            return string.Empty;
        }

        /// <summary>
        ///  Servicio que sube los bonos de altamira para una linea 
        /// </summary>
        /// <param name="primaryTelephoneNumber"></param>
        /// <param name="bono"></param>
        /// <param name="ciclo"></param>
        /// <param name="capacidad"></param>
        /// <param name="BonoTemp">True: Bono Temporal, False: Bono AutoRenovable</param>
        /// <param name="llave"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/PlanesFamiliares/Services/SubirBono/{primaryTelephoneNumber}/{bono}/{ciclo}/{capacidad}/{BonoTemp}/{llave}")]
        public dynamic SubscribeBoltonServicio(string primaryTelephoneNumber, string bono, int ciclo, int capacidad, bool BonoTemp, string llave)
        {
            if (!String.IsNullOrEmpty(primaryTelephoneNumber) && !String.IsNullOrEmpty(bono) && ciclo != 0 && !String.IsNullOrEmpty(llave))
            {
                return _servicesRepository.SubscribeBoltonServicio(primaryTelephoneNumber, bono, ciclo, capacidad, BonoTemp, llave);
            }
            return string.Empty;
        }

        #endregion
    }
}
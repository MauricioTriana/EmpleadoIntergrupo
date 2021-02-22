using Bussiness.EntityFramework;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bussiness.Entities.Appsettings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlanesFamiliares.Bussiness.Helper.DataModel
{
    /// <summary>
    /// Operaciones empleado
    /// </summary>
    public static class empleadoOperations
    {

        /// <summary>
        /// Empleados a consultar
        /// </summary>
        /// <param name="cedula">Numero de empleado a validar</param>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns>Empleados a consultar</returns>
        public static dynamic ConsultarDatosEmpleado(string cedula, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            var valorRetorno = string.Empty;
            try
            {
                if (uris != null && logger != null && cache != null)
                {
                    using (PruebaIntergrupoContext db = new PruebaIntergrupoContext())
                    {
                        var data = (from item in db.Empleado
                                    where item.DocumentoIdentidad == cedula
                                    select item).FirstOrDefault();

                        if ( data != null && !String.IsNullOrEmpty(data.DocumentoIdentidad))
                        {
                            valorRetorno = JsonConvert.SerializeObject(data);
                        }
                    }
                }
                else
                {
                    logger.LogCritical("Problemas al leer los parámetros");
                }
            }catch(Exception er)
            {
                logger.LogCritical("Error al procesar datos del empleado; Error = " + er.ToString());
            }
            return valorRetorno;
        }

        /// <summary>
        /// Consultar todos empleados registrados
        /// </summary>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns>Empleados a consultar</returns>
        public static dynamic ListarEmpleadosAction( IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            var valorRetorno = string.Empty;
            try
            {
                if (uris != null && logger != null && cache != null)
                {
                    using (PruebaIntergrupoContext db = new PruebaIntergrupoContext())
                    {
                        var data = (from item in db.Empleado
                                    select new Empleado { DocumentoIdentidad = item.DocumentoIdentidad, 
                                                          NombreEmpleado = item.NombreEmpleado,
                                                          ApellidoEmpleado = item.ApellidoEmpleado,
                                                          Cargo = item.Cargo,
                                                          IdEmpleado = item.IdEmpleado
                                                        });

                            valorRetorno = JsonConvert.SerializeObject (data, Formatting.None);
                        
                    }
                }
                else
                {
                    logger.LogCritical("Problemas al leer los parámetros");
                }
            }
            catch (Exception er)
            {
                logger.LogCritical("Error al procesar datos de los empleados; Error = " + er.ToString());
            }
            return valorRetorno;
        }


        /// <summary>
        /// Crear un nuevo empleado en BD
        /// </summary>
        /// <param name="newEmpleado">Objeto de empleado a regsitrar</param>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns>mensaje de ejecucion</returns>
        public static dynamic CrearEmpleadoAction(JObject newEmpleado, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            string retorno = "registro fallido";
            if (newEmpleado.Count > 0)
            {
                Empleado dataAsociacion = JsonConvert.DeserializeObject<Empleado>(newEmpleado.ToString());
                using (PruebaIntergrupoContext db = new PruebaIntergrupoContext())
                {
                    db.Empleado.Add(dataAsociacion);
                    db.SaveChanges();

                    retorno = "registro exitoso";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Actualizar un empleado en BD
        /// </summary>
        /// <param name="updEmpleado">Objeto de empleado a actualizar</param>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns>mensaje de ejecucion</returns>
        public static dynamic ActualizarEmpleadoAction(JObject updEmpleado, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            string retorno = "Actualizacion fallida";
            if (updEmpleado.Count > 0)
            {
                Empleado dataActualizacion = JsonConvert.DeserializeObject<Empleado>(updEmpleado.ToString());
                using (PruebaIntergrupoContext db = new PruebaIntergrupoContext())
                {

                    Empleado dataNueva = db.Empleado.Where(x => x.DocumentoIdentidad == dataActualizacion.DocumentoIdentidad).FirstOrDefault();

                    dataNueva.NombreEmpleado = (dataNueva.NombreEmpleado != dataActualizacion.NombreEmpleado) ? dataActualizacion.NombreEmpleado : dataNueva.NombreEmpleado;
                    dataNueva.Cargo = (dataNueva.Cargo != dataActualizacion.Cargo) ? dataActualizacion.Cargo : dataNueva.Cargo;
                    dataNueva.ApellidoEmpleado = (dataNueva.ApellidoEmpleado != dataActualizacion.ApellidoEmpleado) ? dataActualizacion.ApellidoEmpleado : dataNueva.ApellidoEmpleado;

                    db.SaveChanges();

                    retorno = "Actualizacion exitosa";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Validar login del empleado
        /// </summary>
        /// <param name="identificacion">identificacion del empleado</param>
        /// <param name="contrasena">Contraseña del empleado</param>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static dynamic validarLoginEmpleadoAction(string identificacion, string contrasena, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            string retorno = "No se enviaron los datos para loguear el empleado";
            if (!String.IsNullOrEmpty(identificacion) && !String.IsNullOrEmpty(contrasena))
            {
                using (PruebaIntergrupoContext db = new PruebaIntergrupoContext())
                {

                    Empleado dataEmpleado = db.Empleado.Where(x => x.DocumentoIdentidad == identificacion).FirstOrDefault();

                    if ( dataEmpleado != null && !String.IsNullOrEmpty(dataEmpleado.DocumentoIdentidad))
                    {
                        retorno = (dataEmpleado.contrasena == contrasena) ? "OK" : "La contraseña es errada";
                    }
                    else 
                    {
                        retorno = "El empleado descrito con la identificacion: " + identificacion + ", no existe en base de datos";
                    }
                }
            }
            return retorno;
        }
    }
}

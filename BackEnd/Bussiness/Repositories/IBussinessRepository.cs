
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

namespace Bussiness.Repositories
{
    /// <summary>
    /// Interface Bussiness
    /// </summary>
    public interface IBussinessRepository
    {
 
        /// <summary>
        /// Consultar la profesion de un empleado
        /// </summary>  
        /// <param name="cedula">Numero de cedula empleado</param>
        /// <returns>Mensaje de ejecucion correcta</returns>
        string ConsultarDatosEmpleado(string cedula);

        /// <summary>
        /// Consultar la profesion de un empleado
        /// </summary>  
        /// <returns>Mensaje de ejecucion correcta</returns>
        string ListarEmpleados();

        /// <summary>
        /// insertar un empleado en BD
        /// </summary>
        /// <param name="newEmpleado">Objeto de empleado</param>
        /// <returns></returns>
        string CrearEmpleado(JObject newEmpleado);

        /// <summary>
        /// Actualizar un empleado en BD
        /// </summary>
        /// <param name="updEmpleado">Objeto de empleado a actualizar</param>
        /// <returns>mensaje de ejecucion</returns>
        string ActualizarEmpleado(JObject updEmpleado);

        /// <summary>
        /// Validar login del empleado
        /// </summary>
        /// <param name="identificacion">identificacion del empleado</param>
        /// <param name="contrasena">Contraseña del empleado</param>
        /// <returns>OK si cumple con la validacion de la contraseña</returns>
        string validarLoginEmpleado(string identificacion, string contrasena);

    }
}

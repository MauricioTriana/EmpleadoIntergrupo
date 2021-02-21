using System;
using System.Collections.Generic;

namespace Bussiness.EntityFramework
{
    /// <summary>
    /// Caracteristicas del objeto empleado
    /// </summary>
    public partial class Empleado
    {
        /// <summary>
        /// Id unico de empleado
        /// </summary>
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string NombreEmpleado { get; set; }

        /// <summary>
        /// Apellidos del empleado
        /// </summary>
        public string ApellidoEmpleado { get; set; }

        /// <summary>
        /// Documento de identidad del empleado
        /// </summary>
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Cargo que desempeña el empleado en la comunidad
        /// </summary>
        public string Cargo { get; set; }

        /// <summary>
        /// Contraseña del empleado
        /// </summary>
        public string contrasena { get; set; }
    }
}

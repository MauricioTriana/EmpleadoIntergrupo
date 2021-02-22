namespace Bussiness.Entities
{
    /// <summary>
    /// Clase para manejar la configuración de la aplicación.
    /// </summary>
    public class Appsettings
    {
        /// <summary>
        /// Manejo de constantes de la aplicación.
        /// </summary>
        public class Constantes
        {
            /// <summary>
            /// 
            /// </summary>
            public string Novum_Key { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Novum_IV { get; set; }
        }


        /// <summary>
        /// Manejo de las URL de los servicios
        /// </summary>
        public class Uris
        {
            /// <summary>
            /// URL de la API de Servicios
            /// </summary>
            public string Servicios_URI { get; set; }

            /// <summary>
            /// URL de la API de Datos
            /// </summary>
            public string DataModel_URI { get; set; }
        }

    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanesFamiliares.Helper
{
    public static class ExtraerDatoJsonFunction
    {
        public static string ExtraerDatoJson(string responseRest, string llave)
        {
            JObject respuesta = JObject.Parse(responseRest);
            var res = respuesta.GetValue(llave);
            return res==null ? string.Empty : res.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PlanesFamiliares.Helper
{
    public static class  GetTipoBonoFunction
    {
       public static string  GetTipoBono(Enumeraciones.TipoBono tipo)
        {
            string retorno = string.Empty;
            switch (tipo)
            {
                case Enumeraciones.TipoBono.Temporal:
                    retorno = "IBPG";
                    break;
                case Enumeraciones.TipoBono.Renovable:
                    retorno = "IDPR";
                    break;
            }
            return retorno;
        }
    }
}

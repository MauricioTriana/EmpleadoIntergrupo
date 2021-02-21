using System;
using System.Collections.Generic;
using System.Text;

namespace PlanesFamiliares.Helper
{
    public static class CalcularFechaCicloFunction
    {
        public static string CalcularFechaCiclo(int ciclo, string formato)
        {
            DateTime fechaAhora = DateTime.Now;
            DateTime fechaCiclo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, ciclo);
            int diferencia = fechaAhora.Subtract(fechaCiclo).Days;
            if (diferencia > 0)
            {
                fechaCiclo = fechaCiclo.AddMonths(1);
            }
            return fechaCiclo.ToString(formato);
        } 

        public static string CalcularFechaCicloMasUno(int ciclo, string formato)
        {
            DateTime fechaAhora = DateTime.Now;
            DateTime fechaCiclo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, ciclo);
            fechaCiclo = fechaCiclo.AddDays(1);
            int diferencia = fechaAhora.Subtract(fechaCiclo).Days;
            if (diferencia > 0)
            {
                fechaCiclo = fechaCiclo.AddMonths(1);
            }
            return fechaCiclo.ToString(formato);
        }
    }
}

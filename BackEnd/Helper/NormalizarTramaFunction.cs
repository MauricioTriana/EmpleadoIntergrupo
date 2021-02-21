using System;

namespace PlanesFamiliares.Helper
{
    public static class NormalizarTramaFunction
    {
        public static dynamic NormalizarTrama(string trama)
        {
            return trama.Replace(@"\", @"""");
        }
    }
}

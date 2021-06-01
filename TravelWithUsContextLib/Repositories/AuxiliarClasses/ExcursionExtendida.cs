using System;

namespace TravelWithUs.DBContext.Repositories
{
    public class ExcursionExtendida
    {
        public string LugarExcursion { get; private set; }
        public DateTime SalidaExcursion { get; private set; }
        public int DuracionExcursion { get; private set; }

        public ExcursionExtendida(string lugar, DateTime salida, int duracion)
        {
            this.LugarExcursion = lugar;
            this.SalidaExcursion = salida;
            this.DuracionExcursion = duracion;
        }
    }
}
using System;

namespace TravelWithUs.DBContext.Repositories
{
    public class ExcursionExtendida
    {
        public string LugarExcursion { get; private set; }
        public DateTime FechaSalidaExcursion { get; private set; }
        public int DuracionExcursion { get; private set; }

        public ExcursionExtendida(string lugar, DateTime fechasalida, int duracion)
        {
            this.LugarExcursion = lugar;
            this.FechaSalidaExcursion = fechasalida;
            this.DuracionExcursion = duracion;
        }
    }
}
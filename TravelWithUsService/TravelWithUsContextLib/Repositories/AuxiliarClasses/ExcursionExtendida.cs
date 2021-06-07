using System;

namespace TravelWithUsService.DBContext.Repositories
{
    public class ExcursionExtendida
    {
        public string LugarExcursion { get; private set; }
        public DateTime FechaSalidaExcursion { get; private set; }
        public int DuracionExcursion { get; private set; }
        public string Descripcion { get; set; }

        public ExcursionExtendida(string lugar, DateTime fechasalida, int duracion, string descripcion)
        {
            this.LugarExcursion = lugar;
            this.FechaSalidaExcursion = fechasalida;
            this.DuracionExcursion = duracion;
            this.Descripcion = descripcion;
        }
    }
}
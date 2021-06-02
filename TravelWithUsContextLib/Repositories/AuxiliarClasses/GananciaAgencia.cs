namespace TravelWithUs.DBContext.Repositories
{
    public class GananciaAgencia
    {
        public string NombreAgencia { get; private set; }
        public decimal GananciaEsperada { get; private set; }
        public int CantidadDeReservas { get; private set; }

        public GananciaAgencia(string nombre, decimal ganancia, int reservas)
        {
            this.NombreAgencia = nombre;
            this.GananciaEsperada = ganancia;
            this.CantidadDeReservas = reservas;
        }
    }
}
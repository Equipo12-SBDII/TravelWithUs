using System;

namespace TravelWithUsService.DBContext.Repositories
{
    public class ReservaIndividualShow
    {
        public string Agencia { get; private set; }
        public string Turista { get; private set; }
        public string OfertaDescripcion { get; private set; }
        public decimal precio { get; private set; }
        public string Hotel { get; private set; }
        public string Aereolinea { get; set; }
        public int Acompananates { get; private set; }
        public DateTime Entrada { get; private set; }
        public DateTime Salida { get; private set; }

        public ReservaIndividualShow(string agencia, string turista, decimal precio, string hotel, string ofertaDescripcion, string aereolinea, int acompananates, DateTime entrada, DateTime salida)
        {
            this.Agencia = agencia;
            this.Turista = turista;
            this.precio = precio;
            this.Hotel = hotel;
            this.OfertaDescripcion = ofertaDescripcion;
            this.Aereolinea = aereolinea;
            this.Acompananates = acompananates;
            this.Entrada = entrada;
            this.Salida = salida;
        }

    }
}
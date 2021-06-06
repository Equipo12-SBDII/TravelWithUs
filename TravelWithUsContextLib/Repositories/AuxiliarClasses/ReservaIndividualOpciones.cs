using System.Collections.Generic;
using System.Linq;
using System;

namespace TravelWithUs.DBContext.Repositories
{
    public class OfertaParaReserva
    {
        public string Descripcion { get; private set; }
        public int OfertaID { get; private set; }
        public int HotelID { get; private set; }
        public string HotelNombre { get; set; }
        public decimal Price { get; set; }
        public OfertaParaReserva(string descripcion, int ofertaId, int hotelId, string nombreh, decimal price)
        {
            this.Descripcion = descripcion;
            this.OfertaID = ofertaId;
            this.HotelID = hotelId;
            this.HotelNombre = nombreh;
            this.Price = price;
        }
    }
    public class TuristaParaReserva
    {
        public int TuristaID { get; private set; }
        public string Nombre { get; private set; }
        public TuristaParaReserva(int turistaId, string nombre)
        {
            this.TuristaID = turistaId;
            this.Nombre = nombre;
        }
    }

    public class AgenciaParaReserva
    {
        public int AgenciaID { get; private set; }
        public string Nombre { get; private set; }
        public AgenciaParaReserva(int agenciaId, string nombre)
        {
            this.AgenciaID = agenciaId;
            this.Nombre = nombre;

        }

    }

    public class ReservaIndividualOpciones
    {
        public List<OfertaParaReserva> Ofertas { get; private set; }
        public List<TuristaParaReserva> Turistas { get; private set; }
        public List<AgenciaParaReserva> Agencias { get; private set; }
        public ReservaIndividualOpciones(IEnumerable<OfertaParaReserva> ofertas, IEnumerable<TuristaParaReserva> turistas, IEnumerable<AgenciaParaReserva> agencias)
        {
            this.Ofertas = new List<OfertaParaReserva>(ofertas);
            this.Turistas = new List<TuristaParaReserva>(turistas);
            this.Agencias = new List<AgenciaParaReserva>(agencias);
        }



    }

}




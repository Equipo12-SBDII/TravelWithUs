using ICollection;

namespace TravelWithUs.DBContext.Repositories
{
    public class OfertaParaReserva
    {
        public string Descripcion{get;set;}
        public int OfertaID {get;set;}
        public int HotelID{get;set;}
        public OfertaParaReserva(string descripcion, int ofertaId, int hotelId)
        { 
            this.Descripcion = descripcion;
            this.OfertaID = OfertaID;
            this.HotelID = hotelId;
        }
    }
    public class TuristaParaReserva
    {
        public int TuristaID{get; set;}
        public string Nombre {get; set;}
        public TuristaParaReserva(int turistaId, string nombre)
        {
            this.TuristaID = turistaId;
            this.Nombre = nombre;
        }
    }

    public class AgenciaParaReserva
    {   
        public int AgenciaID { get; set;}
        public string Nombre {get; set;}
        public AgenciaParaReserva(int agenciaId, string nombre)
        {
            this.AgenciaID = agenciaId;
            this.Nombre = nombre;

        }
       
    }

 public class  ReservaIndividualOpciones
 { 
     IEnumerable<OfertaParaReserva> Ofertas{ get; set;}
     IEnumerable<TuristaParaReserva> Turistas { get; set;}
     IEnumerable<AgenciaParaReserva> Agencias {get; set;}
     public ReservaIndividualOpciones(IEnumerable<OfertaParaReserva> ofertas, IEnumerable<TuristaParaReserva> turistas, IEnumerable<AgenciaParaReserva> agencias)
     {
         this.Ofertas = ofertas;
         this.Turistas = turistas;
         this.Agencias = agencias;

     }
   
 

 }
    
}




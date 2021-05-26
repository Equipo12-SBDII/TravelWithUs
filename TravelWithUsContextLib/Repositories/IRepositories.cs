using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public interface IAgencia : IRepository<Agencia> { }
    public interface IExcursion : IRepository<Excursion> { }
    public interface IFacilidad : IRepository<Facilidad> { }
    public interface IHotel : IRepository<Hotel> { }
    public interface IOferta : IRepository<Oferta> { }
    public interface IPaquete : IRepository<Paquete> { }
    public interface IReservaExcursion : IRepository<ReservaExcursion> { }
    public interface IReservaIndividual : IRepository<ReservaIndividual> { }
    public interface IReservaPaquete : IRepository<ReservaPaquete> { }
    public interface ITurista : IRepository<Turista> { }
}
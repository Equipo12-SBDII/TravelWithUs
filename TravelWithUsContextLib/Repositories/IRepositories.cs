using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public interface IAgencia : IRepository<Agencia> { }
    public interface IExcursion : IRepository<Excursion> { }
    public interface IFacilidad : IRepository<Facilidad> { }
    public interface IHotel : IRepository<Hotel> { }
    public interface IOferta : IRepositoryReserva<Oferta> { }
    public interface IPaquete : IRepository<Paquete> { }
    public interface IReservaExcursion : IRepositoryReserva<ReservaExcursion> { }
    public interface IReservaIndividual : IRepositoryReserva<ReservaIndividual> { }
    public interface IReservaPaquete : IRepositoryReserva<ReservaPaquete> { }
    public interface ITurista : IRepository<Turista> { }
}
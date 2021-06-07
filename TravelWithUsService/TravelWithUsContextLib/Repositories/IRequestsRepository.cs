using System.Collections.Generic;
using TravelWithUsService.Models;
using System.Threading.Tasks;


namespace TravelWithUsService.DBContext.Repositories
{
    public interface IRequestsRepository
    {
        Task<IEnumerable<HotelEnPaquete>> GetHotelsInPackagesAsync();
        Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync(int idP);
        Task<IEnumerable<GananciaAgencia>> GetExpectedProfitAsync();
        Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTouristAsync();
        Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursion();
        Task<IEnumerable<PaqueteSobreMedia>> GetPackagesOverMean();
        Task<ReservaIndividualOpciones> GetRIOptions();

        Task<IEnumerable<AgenciaParaReserva>> GetAgenciesReserve();
        Task<IEnumerable<OfertaParaReserva>> GetOfferReserve();
        Task<IEnumerable<TuristaParaReserva>> GetTouristReserve();

        Task<IEnumerable<ReservaIndividualShow>> GetReservaIndividualShows();

    }
}
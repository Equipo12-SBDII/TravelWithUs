using System.Collections.Generic;
using TravelWithUs.Models;
using System.Threading.Tasks;


namespace TravelWithUs.DBContext.Repositories
{
    public interface IRequestsRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync();
        Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync(int idP);
        Task<IEnumerable<GananciaAgencia>> GetExpectedProfitAsync();
        Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTouristAsync();
        Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursion();
        Task<PaqueteSobreMedia> GetPackagesOverMean();

    }
}
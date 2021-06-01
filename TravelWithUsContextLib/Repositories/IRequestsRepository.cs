using System.Collections.Generic;
using System.Linq;
using TravelWithUs.Models;



namespace TravelWithUs.DBContext.Repositories
{
    public interface IRequestsRepository
    {
        IEnumerable<Hotel> GetHotelsInPackagesAsync();
        IEnumerable<Hotel> GetHotelsInPackagesAsync(int idP);
        IEnumerable<GananciaAgencia> GetExpectedProfitAsync();
        IEnumerable<TuristaIndividualRepitente> GetTuristasRepitentesAsync();
        IEnumerable<ExcursionExtendida> GetExtendedExcursion();
        PaqueteSobreMedia GetPackagesOverMean();

    }
}
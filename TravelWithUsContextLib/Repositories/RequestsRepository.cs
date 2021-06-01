using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWithUs.Models;
using TravelWithUs.DBContext;

namespace TravelWithUs.DBContext.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        private TravelWithUsDbContext dbContext;
        public RequestsRepository(TravelWithUsDbContext database)
        {
            this.dbContext = database;
        }

        public async Task<IEnumerable<GananciaAgencia>> GetExpectedProfitAsync()
        {
            // ReservaExcursionRepository reRepo = new ReservaExcursionRepository(this.dbContext);
            // ReservaIndividualRepository riRepo = new ReservaIndividualRepository(this.dbContext);
            // ReservaPaqueteRepository rpRepo = new ReservaPaqueteRepository(this.dbContext);

            // var reAll = await reRepo.RetrieveAllAsync();
            // var riAll = await riRepo.RetrieveAllAsync();
            // var rpAll = await rpRepo.RetrieveAllAsync();
            // var reAgencia = reAll.GroupBy(re => re.Excursion.Precio)
            //                 .Where(re => )
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursion()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync(int idP)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaqueteSobreMedia> GetPackagesOverMean()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TuristaIndividualRepitente>> GetTuristasRepitentesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
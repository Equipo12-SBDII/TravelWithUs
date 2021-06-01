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

        public async Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync()
        {
            PaqueteRepository packetRepo = new PaqueteRepository(this.dbContext);
            ExcursionRepository excursionRepo = new ExcursionRepository(this.dbContext);
            //HotelRepository  hotelRepo = new HotelRepository(dbContext);

            //List<Hotel> hotels = new List<Hotel>();

            var allpackage = await packetRepo.RetrieveAllAsync();
            //var allhotels = await hotelRepo.RetrieveAllAsync();
            //foreach package in allpackage

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

        public Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTouristAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
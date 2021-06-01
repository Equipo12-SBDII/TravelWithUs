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
            AgenciaRepository agenciaRepo = new AgenciaRepository(this.dbContext);
            var agencias = await agenciaRepo.RetrieveAllAsync();
            IEnumerable<GananciaAgencia> query = agencias
                .Select(a => new GananciaAgencia(
                    a.Nombre,
                    a.ReservasExcursiones.Sum(re => re.Excursion.Precio)
                    + a.ReservasIndividuales.Sum(ri => ri.Precio)
                    + a.ReservasPaquetes.Sum(rp => rp.Precio)
                    , a.ReservasExcursiones.Count + a.ReservasIndividuales.Count + a.ReservasPaquetes.Count)
                );

            return query;
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

<<<<<<< HEAD
        public async Task<IEnumerable<TuristaIndividualRepitente>> GetTuristasRepitentesAsync()
=======
        public Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTouristAsync()
>>>>>>> d495176b3b9eb4f5800878a1d7ab5dca852dc259
        {
            TuristaRepository turistaRepo = new TuristaRepository(this.dbContext);
            var turistas = await turistaRepo.RetrieveAllAsync();
            var query = turistas.Select(t => new TuristaIndividualRepitente(
                    t.Nombre, t.Email
                    , t.ReservasIndividuales.Count
                ))
                .Where(tr => tr.CantidadViajes > 1);

            return query;
        }
    }
}
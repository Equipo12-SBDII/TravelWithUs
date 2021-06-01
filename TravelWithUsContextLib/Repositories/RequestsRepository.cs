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

            var query = agencias.Select(a => new GananciaAgencia(
                a.Nombre,
                a.ReservasExcursiones.Sum(re => re.Excursion.Precio)
                + a.ReservasIndividuales.Sum(ri => ri.Precio)
                + a.ReservasPaquetes.Sum(rp => rp.Precio)
                , a.ReservasExcursiones.Count
                + a.ReservasIndividuales.Count
                + a.ReservasPaquetes.Count)
                );

            return query;
        }

        public Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursion()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync()
        {
            HotelRepository hotelRepo = new HotelRepository(this.dbContext);

            var hoteles = await hotelRepo.RetrieveAllAsync();
            var query = hoteles.Where(h =>
                    h.Excursiones.Count > 0
                    && h.Excursiones.Any(e => e.Paquetes.Count > 0)
                    );

            return query;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync(int idP)
        {
            PaqueteRepository paqueteRepo = new PaqueteRepository(this.dbContext);
            var paquete = await paqueteRepo.RetrieveAsync(idP);
            return paquete.Excursion.Hoteles;
        }

        public async Task<PaqueteSobreMedia> GetPackagesOverMean()
        {
            PaqueteRepository paqueteRepo = new PaqueteRepository(this.dbContext);
            var paquetes = await paqueteRepo.RetrieveAllAsync();
            decimal media = paquetes.Average(p => p.Precio);
            var query = new PaqueteSobreMedia(paquetes.Where(
                p => p.Precio > media
            ));

            return query;
        }


        public async Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTouristAsync()
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
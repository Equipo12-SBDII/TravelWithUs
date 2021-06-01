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
            ExcursionRepository excursionRepo = new ExcursionRepository(this.dbContext);
            var excursiones = excursionRepo.RetrieveAllAsync();
            var query = excursiones.Where(h => h.Hoteles != null).Select(e => new ExcursionExtendida(e.LugarSalida, e.FechaSalida, long(dateDiff("d", e.FechaLlegada, e.FechaSalida))));
            return query;       
            
        }

        public async Task<IEnumerable<Hotel>> GetHotelsInPackagesAsync()
        {
            PaqueteRepository packageRepo = new PaqueteRepository(this.dbContext);
            ExcursionRepository excursionRepo = new ExcursionRepository(this.dbContext);
           
            var allpackage = await packetRepo.RetrieveAllAsync();
        
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
            var query = turistas.Where(t => t.ReservasIndividuales.Count > 1)
            .Select(t => new TuristaIndividualRepitente(
                t.Nombre, t.Email, t.ReservasIndividuales.Count
            ));

            return query;
        }
    }
}
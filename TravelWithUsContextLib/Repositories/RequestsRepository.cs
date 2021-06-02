using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWithUs.Models;
using TravelWithUs.DBContext;
using System;

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
                (a.ReservasExcursiones != null ?
                  a.ReservasExcursiones.Sum(re => re.Excursion.Precio) : 0)
                + (a.ReservasIndividuales != null ?
                    a.ReservasIndividuales.Sum(ri => ri.Precio) : 0)
                + (a.ReservasPaquetes != null ?
                    a.ReservasPaquetes.Sum(rp => rp.Precio) : 0)
                , a.ReservasExcursiones.Count
                + a.ReservasIndividuales.Count
                + a.ReservasPaquetes.Count)
                );

            return query;
        }

        public async Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursion()
        {
            ExcursionRepository excursionRepo = new ExcursionRepository(this.dbContext);
            var excursiones = await excursionRepo.RetrieveAllAsync();
            var query = excursiones.Where(h => h.Hoteles.Count > 0)
                    .Select(e => new ExcursionExtendida(
                        e.LugarSalida
                        , e.FechaSalida
                        , (int)e.FechaLlegada.Subtract(e.FechaSalida).Days));
            return query;

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




        public async Task<IEnumerable<PaqueteSobreMedia>> GetPackagesOverMean()
        {
            PaqueteRepository paqueteRepo = new PaqueteRepository(this.dbContext);
            var paquetes = await paqueteRepo.RetrieveAllAsync();
            decimal media = paquetes.Average(p => p.Precio);
            var query = paquetes.Select(p => new PaqueteSobreMedia(
                p.Codigo, (int)p.Duracion.Hours, p.Descripcion, p.Precio
            )).Where(pom => pom.Precio > media);

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
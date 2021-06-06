using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelWithUs.DBContext.Repositories
{
    // ReservaIndividual usa llaves de tipo ri => new { ri.AgenciaID, ri.HotelID, ri.OfertaID, ri.TuristaID });
    public class ReservaIndividualRepository : IReservaIndividual
    {
        private static ConcurrentDictionary<(int, int, int, int, int), ReservaIndividual> reservaIndividualCache;
        private TravelWithUsDbContext db;

        public ReservaIndividualRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (reservaIndividualCache == null)
            {
                reservaIndividualCache = new ConcurrentDictionary<(int, int, int, int, int), ReservaIndividual>(
                    this.db.ReservasIndividuales
                    .Include(ri => ri.Turista)
                    .Include(ri => ri.Agencia)
                    .Include(ri => ri.Oferta)
                        .ThenInclude(o => o.Hotel)
                    .ToDictionary(
                        ri => (ri.ReservaIndividualID, ri.AgenciaID, ri.HotelID, ri.OfertaID, ri.TuristaID)));

            }
        } //me preocupan los metodos del concurrente dictionary
        public async Task<ReservaIndividual> CreateAsync(ReservaIndividual ri)
        {
            await this.db.ReservasIndividuales.AddAsync(ri);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaIndividualCache.AddOrUpdate((ri.ReservaIndividualID, ri.AgenciaID, ri.HotelID, ri.OfertaID, ri.TuristaID),
                    ri, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idRi, int idA, int idH, int idO, int idT)
        {
            var key = (idRi, idA, idH, idO, idT);
            ReservaIndividual ri = await this.db.ReservasIndividuales.FindAsync(idA, idH, idO, idT);
            this.db.ReservasIndividuales.Remove(ri);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaIndividualCache.TryRemove(key, out ri);
            }
            return null;
        }

        public Task<IEnumerable<ReservaIndividual>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<ReservaIndividual>>(
                () =>
                {
                    return reservaIndividualCache.Values;
                }
            );
        }

        public Task<ReservaIndividual> RetrieveAsync(int idRi, int idA, int idH, int idO, int idT)
        {
            var key = (idRi, idA, idH, idO, idT);
            return Task.Run(
                () =>
                {
                    reservaIndividualCache.TryGetValue(key, out ReservaIndividual ri);
                    return ri;
                }
            );
        }

        public async Task<ReservaIndividual> UpdateAsync(ReservaIndividual ri, int idRi, int idA, int idH, int idO, int idT)
        {
            var key = (idRi, idA, idH, idO, idT);
            this.db.ReservasIndividuales.Update(ri);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(key, ri);
            }

            return null;
        }

        private ReservaIndividual UpdateCache((int, int, int, int, int) key, ReservaIndividual r)
        {
            ReservaIndividual old;
            if (reservaIndividualCache.TryGetValue(key, out old))
            {
                if (reservaIndividualCache.TryUpdate(key, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }

}
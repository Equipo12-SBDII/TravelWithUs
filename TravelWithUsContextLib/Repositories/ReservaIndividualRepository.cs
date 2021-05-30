using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class ReservaIndividualRepository : IReservaIndividual
    {
        private static ConcurrentDictionary<int, ReservaIndividual> reservaIndividualCache;
        private TravelWithUsDbContext db;

        public ReservaIndividualRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if ( reservaindividualCache == null)
            {
                reservaIndividualCache = new ConcurrentDictionary<int,ReservaIndividual>(
                    this.db.ReservasIndividuales.ToDictionary(re =using System.Collections.Concurrent;

            }
        } //me preocupan los metodos del concurrente dictionary
         public async Task<ReservaIndividual> CreateAsync(ReservaIndividual r)
        {
            await this.db.ReservasIndividuales.AddAsync(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaIndividualCache.AddOrUpdate(r.ReservaIndividualID,  r, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idA, int idO, int idT)
        {
            ReservaExcursion r = await this.db.ReservasIndividuales.FindAsync(int idA, int idO, int idT);
            this.db.ReservasIndividuales.Remove(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaExcursionCache.TryRemove(int idA, int idO, int idT, out r);  
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

        public Task<ReservaExcursion> RetrieveAsync(int idA, int idO, int idT)
        {
            return Task.Run(
                () =>
                {
                    reservaIndividualCache.TryGetValue(int idA, int idO, int idT, out ReservaIndividual r);
                    return r;
                }
            );
        }

        public async Task<ReservaIndividual> UpdateAsync(int idA, int idO, int idT, ReservaIndividual r)
        {
            this.db.ReservasIndividuales.Update(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(int idA, int idE, int idT, r);
            }

            return null;
        }

        private ReservaIndividual UpdateCache(int idA, int idO, int idT,, ReservaIndividual r)
        {
            ReservaIndividual old;
            if (reservaIndividualCache.TryGetValue(int idA, int idO, int idT, out old))
            {
                if (reservaIndividualCache.TryUpdate(int idA, int idO, int idT, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }

}
using System.Collections.Concurrent;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class ReservaExcursionRepository : IReservaExcursion
    {
        private static ConcurrentDictionary<int, ReservaExcursion> reservaExcursionCache;
        private TravelWithUsDbContext db;

        public ReservaExcursionRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (reservaExcursionCache == null)
            {
                reservaExcursionCache = new ConcurrentDictionary<int, ReservaExcursion>(
                    this.db.ReservasExcursiones.ToDictionary(re => re.ReservaExcursionID)
                );
            }
        }
        public async Task<ReservaExcursion> CreateAsync(ReservaExcursion r)
        {
            await this.db.ReservasExcursiones.AddAsync(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaExcursionCache.AddOrUpdate(r.ReservaExcursionID, r, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idA, int idE, int idT)
        {
            ReservaExcursion r = await this.db.ReservasExcursiones.FindAsync(int idA, int idE, int idT);
            this.db.ReservasExcursiones.Remove(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaExcursionCache.TryRemove(int idA, int idE, int idT, out r);  //Me preocupa este metodo
            }
            return null;
        }

        public Task<IEnumerable<ReservaExcursione>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<ReservaExcursion>>(
                () =>
                {
                    return reservaExcursionCache.Values;
                }
            );
        }

        public Task<ReservaExcursion> RetrieveAsync(int idA, int idE, int idT)
        {
            return Task.Run(
                () =>
                {
                    reservaExcursionCache.TryGetValue(int idA, int idE, int idT, out ReservaExcursion r);
                    return r;
                }
            );
        }

        public async Task<ReservaExcursion> UpdateAsync(int idA, int idE, int idT, ReservaExcursion r)
        {
            this.db.ReservasExcursiones.Update(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(int idA, int idE, int idT, r);
            }

            return null;
        }

        private ReservaExcursion UpdateCache(int idA, int idE, int idT,, ReservaExcursion r)
        {
            ReservaExcursion old;
            if (reservaExcursionCache.TryGetValue(int idA, int idE, int idT, out old))
            {
                if (reservaExcursionCache.TryUpdate(int idA, int idE, int idT, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }
}
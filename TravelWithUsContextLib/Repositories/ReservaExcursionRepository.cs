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
        // ReservaExcursion usa llaves de tipo re => new { re.AgenciaID, re.ExcursionID, re.TuristaID });
        private static ConcurrentDictionary<(int, int, int), ReservaExcursion> reservaExcursionCache;
        private TravelWithUsDbContext db;

        public ReservaExcursionRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (reservaExcursionCache == null)
            {
                reservaExcursionCache = new ConcurrentDictionary<(int, int, int), ReservaExcursion>(
                    this.db.ReservasExcursiones.ToDictionary(
                        re => (re.AgenciaID, re.ExcursionID, re.TuristaID))
                );
            }
        }
        public async Task<ReservaExcursion> CreateAsync(ReservaExcursion re)
        {
            await this.db.ReservasExcursiones.AddAsync(re);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaExcursionCache.AddOrUpdate((re.AgenciaID, re.ExcursionID, re.TuristaID),
                    re, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idA, int idE, int idT)
        {
            ReservaExcursion r = await this.db.ReservasExcursiones.FindAsync(idA, idE, idT);
            this.db.ReservasExcursiones.Remove(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaExcursionCache.TryRemove((idA, idE, idT), out r);  //Me preocupa este metodo
            }
            return null;
        }

        public Task<IEnumerable<ReservaExcursion>> RetrieveAllAsync()
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
            var key = (idA, idE, idT);
            return Task.Run(
                () =>
                {
                    reservaExcursionCache.TryGetValue(key, out ReservaExcursion r);
                    return r;
                }
            );
        }

        public async Task<ReservaExcursion> UpdateAsync(ReservaExcursion r, int idA, int idE, int idT)
        {
            var key = (idA, idE, idT);
            this.db.ReservasExcursiones.Update(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(key, r);
            }

            return null;
        }

        private ReservaExcursion UpdateCache((int, int, int) key, ReservaExcursion r)
        {
            ReservaExcursion old;
            if (reservaExcursionCache.TryGetValue(key, out old))
            {
                if (reservaExcursionCache.TryUpdate(key, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }
}

using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelWithUs.DBContext.Repositories
{
    public class ExcursionRepository : IExcursion
    {
        private static ConcurrentDictionary<int, Excursion> excursionCache;

        private TravelWithUsDbContext db;

        public ExcursionRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (excursionCache == null)
            {
                excursionCache = new ConcurrentDictionary<int, Excursion>(
                    this.db.Excursiones
                    .Include(e => e.Hoteles)
                    .ToDictionary(e => e.ExcursionID)
                );
            }

        }
        public async Task<Excursion> CreateAsync(Excursion e)
        {
            await this.db.AddAsync(e);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return excursionCache.AddOrUpdate(e.ExcursionID, e, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Excursion e = await this.db.Excursiones.FindAsync(id);
            this.db.Excursiones.Remove(e);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return excursionCache.TryRemove(id, out e);
            }

            return null;

        }

        public Task<IEnumerable<Excursion>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Excursion>>(
                () =>
                {
                    return excursionCache.Values;
                }
            );
        }

        public Task<Excursion> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    excursionCache.TryGetValue(id, out Excursion e);
                    return e;
                }
            );
        }

        public async Task<Excursion> UpdateAsync(int id, Excursion e)
        {
            this.db.Excursiones.Update(e);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return this.UpdateCache(id, e);
            }
            return null;
        }

        private Excursion UpdateCache(int id, Excursion e)
        {
            Excursion old;
            if (excursionCache.TryGetValue(id, out old))
            {
                if (excursionCache.TryUpdate(id, e, old))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
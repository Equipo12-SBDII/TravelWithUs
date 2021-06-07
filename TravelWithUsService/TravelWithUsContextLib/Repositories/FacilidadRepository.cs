using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUsService.Models;

namespace TravelWithUsService.DBContext.Repositories
{
    public class FacilidadRepository : IFacilidad
    {
        private static ConcurrentDictionary<int, Facilidad> facilidadCache;

        private TravelWithUsDbContext db;

        public FacilidadRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (facilidadCache == null)
            {
                facilidadCache = new ConcurrentDictionary<int, Facilidad>(
                    this.db.Facilidades.ToDictionary(f => f.FacilidadID)
                );
            }
        }
        public async Task<Facilidad> CreateAsync(Facilidad f)
        {
            await this.db.Facilidades.AddAsync(f);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return facilidadCache.AddOrUpdate(f.FacilidadID, f, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Facilidad f = await this.db.Facilidades.FindAsync(id);
            this.db.Facilidades.Remove(f);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return facilidadCache.TryRemove(id, out f);
            }
            return null;
        }

        public Task<IEnumerable<Facilidad>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Facilidad>>(
                () =>
                {
                    return facilidadCache.Values;
                }
            );
        }

        public Task<Facilidad> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    facilidadCache.TryGetValue(id, out Facilidad f);
                    return f;
                }
            );
        }

        public async Task<Facilidad> UpdateAsync(int id, Facilidad f)
        {
            this.db.Facilidades.Update(f);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return this.UpdateCache(id, f);
            }
            return null;
        }

        private Facilidad UpdateCache(int id, Facilidad f)
        {
            Facilidad old;
            facilidadCache.TryGetValue(id, out old);

            if (facilidadCache.TryUpdate(id, f, old))
            {
                return old;
            }
            return null;
        }
    }
}
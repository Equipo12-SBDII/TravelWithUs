using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class PaqueteRepository : IPaquete
    {
        private static ConcurrentDictionary<int, Paquete> paqueteCache;
        private TravelWithUsDbContext db;

        public PaqueteRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (paqueteCache == null)
            {
                paqueteCache = new ConcurrentDictionary<int, Paquete>(
                    this.db.Paquetes.ToDictionary(p => p.PaqueteID)
                );
            }
        }
        public async Task<Paquete> CreateAsync(Paquete p)
        {
            await this.db.Paquetes.AddAsync(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return hotelCache.AddOrUpdate(p.PaqueteID, p, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Paquete p = await this.db.Paquetes.FindAsync(id);
            this.db.Paquetes.Remove(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return hotelCache.TryRemove(id, out p);
            }
            return null;
        }

        public Task<IEnumerable<Hotel>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Hotel>>(
                () =>
                {
                    return paqueteCache.Values;
                }
            );
        }

        public Task<Hotel> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    hotelCache.TryGetValue(id, out Paquete p);
                    return p;
                }
            );
        }

        public async Task<Hotel> UpdateAsync(int id, Hotel h)
        {
            this.db.Hoteles.Update(h);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, h);
            }

            return null;
        }

        private Hotel UpdateCache(int id, Hotel h)
        {
            Hotel old;
            if (hotelCache.TryGetValue(id, out old))
            {
                if (hotelCache.TryUpdate(id, h, old))
                {
                    return h;
                }
            }
            return null;
        }
    }
}
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUsService.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelWithUsService.DBContext.Repositories
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
                    this.db.Paquetes
                    .Include(p => p.Excursion.Hoteles)
                    .ToDictionary(p => p.Codigo)
                );
            }
        }
        public async Task<Paquete> CreateAsync(Paquete p)
        {
            await this.db.Paquetes.AddAsync(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return paqueteCache.AddOrUpdate(p.Codigo, p, this.UpdateCache);
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
                return paqueteCache.TryRemove(id, out p);
            }
            return null;
        }

        public Task<IEnumerable<Paquete>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Paquete>>(
                () =>
                {
                    return paqueteCache.Values;
                }
            );
        }

        public Task<Paquete> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    paqueteCache.TryGetValue(id, out Paquete p);
                    return p;
                }
            );
        }

        public async Task<Paquete> UpdateAsync(int id, Paquete p)
        {
            this.db.Paquetes.Update(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, p);
            }

            return null;
        }

        private Paquete UpdateCache(int id, Paquete h)
        {
            Paquete old;
            if (paqueteCache.TryGetValue(id, out old))
            {
                if (paqueteCache.TryUpdate(id, h, old))
                {
                    return h;
                }
            }
            return null;
        }
    }
}
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using TravelWithUs.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TravelWithUs.DBContext.Repositories
{
    public class AgenciaRepository : IAgencia
    {
        private static ConcurrentDictionary<int, Agencia> agenciaCache;
        private TravelWithUsDbContext db;

        public AgenciaRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (agenciaCache == null)
            {
                agenciaCache = new ConcurrentDictionary<int, Agencia>(
                    this.db.Agencias
                    .Include(a => a.ReservasExcursiones)
                        .ThenInclude(re => re.Excursion)
                    .Include(a => a.ReservasIndividuales)
                    .Include(a => a.ReservasPaquetes)
                    .ToDictionary(a => a.AgenciaID)
                );
            }
        }
        public async Task<Agencia> CreateAsync(Agencia a)
        {
            await db.Agencias.AddAsync(a);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return agenciaCache.AddOrUpdate(a.AgenciaID, a, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Agencia a = await this.db.Agencias.FindAsync(id);
            this.db.Agencias.Remove(a);
            int affected = await this.db.SaveChangesAsync();

            if (affected == 1)
            {
                return agenciaCache.TryRemove(id, out a);
            }
            return null;
        }

        public Task<IEnumerable<Agencia>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Agencia>>(
                () => agenciaCache.Values
            );
        }

        public Task<Agencia> RetrieveAsync(int id)
        {
            return Task.Run(() =>
           {
               agenciaCache.TryGetValue(id, out Agencia a);
               return a;
           });
        }

        public async Task<Agencia> UpdateAsync(int id, Agencia a)
        {
            db.Agencias.Update(a);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, a);
            }
            return null;

        }

        private Agencia UpdateCache(int id, Agencia a)
        {
            Agencia old;
            if (agenciaCache.TryGetValue(id, out old))
            {
                if (agenciaCache.TryUpdate(id, a, old))
                {
                    return a;
                }
            }
            return null;
        }

    }
}
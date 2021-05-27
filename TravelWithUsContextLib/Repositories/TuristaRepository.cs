<<<<<<< HEAD
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class TuristaRepository : ITurista
    {
        private static ConcurrentDictionary<int, Turista> turistaCache;
        private TravelWithUsDbContext db;

        public TuristaRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (turistaCache == null)
            {
                turistaCache = new ConcurrentDictionary<int, Turista>(
                    this.db.Turistas.ToDictionary(t => t.TuristaID)
                );
            }
        }
        public async Task<turista> CreateAsync(Turista t)
        {
            await this.db.Turistas.AddAsync(t);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return turistaCache.AddOrUpdate(t,TuristaID, t, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            turista t= await this.db.Turistas.FindAsync(id);
            this.db.Turistas.Remove(t);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return turistaCache.TryRemove(id, out t);
            }
            return null;
        }

        public Task<IEnumerable<Turista>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Turista>>(
                () =>
                {
                    return turistaCache.Values;
                }
            );
        }

        public Task<Turista> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    turistaCache.TryGetValue(id, out Turista t);
                    return t;
                }
            );
        }

        public async Task<Turista> UpdateAsync(int id, Turista t)
        {
            this.db.Turistas.Update(t);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, t);
            }

            return null;
        }

        private Turista UpdateCache(int id, Turista t)
        {
            Turista old;
            if (turistaCache.TryGetValue(id, out old))
            {
                if (turistaCache.TryUpdate(id, t, old))
                {
                    return t;
                }
            }
            return null;
        }
    }
=======
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class TuristaRepository : ITurista
    {
        private static ConcurrentDictionary<int, Turista> turistaCache;
        private TravelWithUsDbContext db;
        public TuristaRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (turistaCache == null)
            {
                turistaCache = new ConcurrentDictionary<int, Turista>(
                    this.db.Turistas.ToDictionary(t => t.TuristaID)
                );
            }
        }
        public Task<Turista> CreateAsync(Turista t)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool?> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Turista>> RetrieveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Turista> RetrieveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Turista> UpdateAsync(int id, Turista t)
        {
            throw new System.NotImplementedException();
        }
    }
>>>>>>> b377120cd8af49aceaf13973d0c8b50c6de962b4
}
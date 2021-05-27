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
}
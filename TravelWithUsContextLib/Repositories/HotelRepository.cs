using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class HotelRepository : IHotel
    {
        private static ConcurrentDictionary<int, Hotel> hotelCache;
        private TravelWithUsDbContext db;

        public HotelRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (hotelCache == null)
            {
                hotelCache = new ConcurrentDictionary<int, Hotel>(
                    this.db.Hoteles.ToDictionary(h => h.HotelID)
                );
            }
        }
        public async Task<Hotel> CreateAsync(Hotel h)
        {
            await this.db.Hoteles.AddAsync(h);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return hotelCache.AddOrUpdate(h.HotelID, h, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Hotel h = await this.db.Hoteles.FindAsync(id);
            this.db.Hoteles.Remove(h);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return hotelCache.TryRemove(id, out h);
            }
            return null;
        }

        public Task<IEnumerable<Hotel>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Hotel>>(
                () =>
                {
                    return hotelCache.Values;
                }
            );
        }

        public Task<Hotel> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    hotelCache.TryGetValue(id, out Hotel h);
                    return h;
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
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    // Oferta usa llaves de tipo o => new { o.OfertaID, o.HotelID };
    public class OfertaRepository : IOferta
    {
        private static ConcurrentDictionary<(int, int), Oferta> ofertaCache;
        private TravelWithUsDbContext db;

        public OfertaRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (ofertaCache == null)
            {
                ofertaCache = new ConcurrentDictionary<(int, int), Oferta>(
                    this.db.Ofertas.ToDictionary(o => (o.OfertaID, o.HotelID))
                );
            }
        }
        public async Task<Oferta> CreateAsync(Oferta o)
        {
            await this.db.Ofertas.AddAsync(o);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return ofertaCache.AddOrUpdate((o.OfertaID, o.HotelID), o, UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int ofertaId, int hotelId)
        {
            var key = (ofertaId, hotelId);
            Oferta oferta = await this.db.Ofertas.FindAsync(ofertaId, hotelId);
            this.db.Ofertas.Remove(oferta);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return ofertaCache.TryRemove(key, out oferta);
            }
            return null;
        }

        public Task<IEnumerable<Oferta>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Oferta>>(
                () =>
                {
                    return ofertaCache.Values;
                }
            );
        }

        public Task<Oferta> RetrieveAsync(int ofertaId, int hotelId)
        {
            var key = (ofertaId, hotelId);
            return Task.Run(
                () =>
                {
                    ofertaCache.TryGetValue(key, out Oferta oferta);
                    return oferta;
                }
            );
        }

        public async Task<Oferta> UpdateAsync(Oferta oferta, int ofertaId, int hotelId)
        {
            var key = (ofertaId, hotelId);
            this.db.Ofertas.Update(oferta);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(key, oferta);
            }

            return null;
        }

        private Oferta UpdateCache((int, int) key, Oferta oferta)
        {
            Oferta old;
            if (ofertaCache.TryGetValue(key, out old))
            {
                if (ofertaCache.TryUpdate(key, oferta, old))
                {
                    return oferta;
                }
            }
            return null;
        }
    }
}
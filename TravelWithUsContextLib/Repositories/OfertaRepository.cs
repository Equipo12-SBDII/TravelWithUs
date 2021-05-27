using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class OfertaRepository : IOferta
    {
        private static ConcurrentDictionary<int, Oferta> ofertaCache;
        private TravelWithUsDbContext db;

        public OfertaRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (ofertaCache == null)
            {
                ofertaCache = new ConcurrentDictionary<int, Oferta>(
                    this.db.Ofertas.ToDictionary(o => o.OfertaID)
                );
            }
        }
        public async Task<Hotel> CreateAsync(Oferta oferta)
        {
            await this.db.Ofertas.AddAsync(oferta);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return ofertaCache.AddOrUpdate(oferta.OfertaID, oferta, UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Oferta oferta = await this.db.Ofertas.FindAsync(id);
            this.db.Ofertas.Remove(oferta);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return ofertaCache.TryRemove(id, out oferta);
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

        public Task<Oferta> RetrieveAsync(int id)
        {
            return Task.Run(
                () =>
                {
                    hotelCache.TryGetValue(id, out Oferta oferta);
                    return oferta;
                }
            );
        }

        public async Task<Oferta> UpdateAsync(int id, Oferta oferta)
        {
            this.db.Ofertas.Update(h);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, oferta);
            }

            return null;
        }

        private Oferta UpdateCache(int id,Oferta oferta)
        {
            Oferta old;
            if (ofertaCache.TryGetValue(id, out old))
            {
                if (ofertaCache.TryUpdate(id, oferta, old))
                {
                    return oferta;
                }
            }
            return null;
        }
    }
}
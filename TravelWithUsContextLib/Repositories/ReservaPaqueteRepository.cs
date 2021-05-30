using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{

    public class ReservaPaqueteRepository : IReservaPaquete
    {
        // ReservaExcursion usa llaves de tipo rp => new { rp.AgenciaID, rp.TuristaID, rp.Codigo };
        private static ConcurrentDictionary<(int, int, int), ReservaPaquete> reservaPaqueteCache;
        private TravelWithUsDbContext db;

        public ReservaPaqueteRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if (reservaPaqueteCache == null)
            {
                reservaPaqueteCache = new ConcurrentDictionary<(int, int, int), ReservaPaquete>(
                    this.db.ReservasPaquetes.ToDictionary(
                        rp => (rp.AgenciaID, rp.TuristaID, rp.Codigo)));

            }
        } //me preocupan los metodos del concurrente dictionary
        public async Task<ReservaPaquete> CreateAsync(ReservaPaquete rp)
        {
            await this.db.ReservasPaquetes.AddAsync(rp);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaPaqueteCache.AddOrUpdate((rp.AgenciaID, rp.TuristaID, rp.Codigo),
                    rp, this.UpdateCache);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idA, int idT, int codigoP)
        {
            var key = (idA, idT, codigoP);
            ReservaPaquete rp = await this.db.ReservasPaquetes.FindAsync(idA, idT, codigoP);
            this.db.ReservasPaquetes.Remove(rp);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaPaqueteCache.TryRemove(key, out rp);
            }
            return null;
        }

        public Task<IEnumerable<ReservaPaquete>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<ReservaPaquete>>(
                () =>
                {
                    return reservaPaqueteCache.Values;
                }
            );
        }

        public Task<ReservaPaquete> RetrieveAsync(int idA, int idT, int codigoP)
        {
            var key = (idA, idT, codigoP);
            return Task.Run(
                () =>
                {
                    reservaPaqueteCache.TryGetValue(key, out ReservaPaquete r);
                    return r;
                }
            );
        }

        public async Task<ReservaPaquete> UpdateAsync(ReservaPaquete r, int idA, int idT, int codigoP)
        {
            var key = (idA, idT, codigoP);
            this.db.ReservasPaquetes.Update(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(key, r);
            }

            return null;
        }

        private ReservaPaquete UpdateCache((int, int, int) key, ReservaPaquete r)
        {
            ReservaPaquete old;
            if (reservaPaqueteCache.TryGetValue(key, out old))
            {
                if (reservaPaqueteCache.TryUpdate(key, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }

}
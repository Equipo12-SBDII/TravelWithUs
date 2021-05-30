using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext.Repositories
{
    public class ReservaPaqueteRepository : IReservaPaquete
    {
        private static ConcurrentDictionary<int, ReservaPaquete> reservaPaqueteCache;
        private TravelWithUsDbContext db;

        public ReservaPaqueteRepository(TravelWithUsDbContext dataBase)
        {
            this.db = dataBase;

            if ( reservaPaqueteCache == null)
            {
                reservaPaqueteCache = new ConcurrentDictionary<int,ReservaPaquete>(
                    this.db.ReservasPaquetes.ToDictionary(re =using System.Collections.Concurrent;

            }
        } //me preocupan los metodos del concurrente dictionary
         public async Task<ReservaPaquete> CreateAsync(ReservaPaquete r)
        {
            await this.db.ReservasPaquetes.AddAsync(p);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaPaqueteCache.AddOrUpdate(r.CodigoP,  r, this.UpdateCache);// q hacer con este?
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int idA, int idT, int codigoP,)
        {
            ReservaExcursion r = await this.db.ReservasPaquetes.FindAsync(int idA, int codigoP, int idT);
            this.db.ReservasPaquetes.Remove(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return reservaPaqueteCache.TryRemove(int idA ,int codigoP, int idT, out r);  
            }
            return null;
        }

        public Task<IEnumerable<ReservaPaquete>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<ReservaIndividual>>(
                () =>
                {
                    return reservaPaqueteCache.Values;
                }
            );
        }

        public Task<ReservaPaquete> RetrieveAsync(int idA, int codigoP, int idT)
        {
            return Task.Run(
                () =>
                {
                    reservaPaqueteCache.TryGetValue(int idA, int codigoP, int idT, out ReservaPaquete r);
                    return r;
                }
            );
        }

        public async Task<ReservaPaquete> UpdateAsync(int idA, int codigoP, int idT, ReservaPaquete r)
        {
            this.db.ReservasPaquetes.Update(r);
            int affected = await this.db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(int idA, int codigoP, int idT, r);
            }

            return null;
        }

        private ReservaPaquete UpdateCache(int idA, int codigoP, int idT, ReservaPaquete r)
        {
            ReservaPaquete old;
            if (reservaPaqueteCache.TryGetValue(int idA, int codigoP, int idT, out old))
            {
                if (reservaPaqueteCache.TryUpdate(int idA, int codigoP, int idT, r, old))
                {
                    return r;
                }
            }
            return null;
        }
    }

}
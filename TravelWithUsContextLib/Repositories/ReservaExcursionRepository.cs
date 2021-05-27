// using System.Collections.Concurrent;
// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using TravelWithUs.Models;

// namespace TravelWithUs.DBContext.Repositories
// {
//     public class ReservaExcursionRepository : IReservaExcursion
//     {
//         private static ConcurrentDictionary<int, ReservaExcursion> reservaExcursionCache;
//         private TravelWithUsDbContext db;

//         public ReservaExcursionRepository(TravelWithUsDbContext dataBase)
//         {
//             this.db = dataBase;

//             if (reservaExcursionCache == null)
//             {
//                 reservaExcursionCache = new ConcurrentDictionary<int, ReservaExcursion>(
//                     this.db.ReservasExcursiones.ToDictionary(re => re.ReservaExcursionID)
//                 );
//             }
//         }
//         public async Task<ReservaExcursion> CreateAsync(ReservaExcursion r)
//         {
//             await this.db.ReservasExcursiones.AddAsync(p);
//             int affected = await this.db.SaveChangesAsync();
//             if (affected == 1)
//             {
//                 return reservaExcursionCache.AddOrUpdate(r.ReservaExcursionID, r, this.UpdateCache);
//             }
//             return null;
//         }

//         public async Task<bool?> DeleteAsync(int id)
//         {
//             ReservaExcursion r = await this.db.ReservasExcursiones.FindAsync(id);
//             this.db.ReservasExcursiones.Remove(r);
//             int affected = await this.db.SaveChangesAsync();
//             if (affected == 1)
//             {
//                 return reservaExcursionCache.TryRemove(id, out r);
//             }
//             return null;
//         }

//         public Task<IEnumerable<ReservaExcursione>> RetrieveAllAsync()
//         {
//             return Task.Run<IEnumerable<ReservaExcursion>>(
//                 () =>
//                 {
//                     return reservaExcursionCache.Values;
//                 }
//             );
//         }

//         public Task<ReservaExcursion> RetrieveAsync(int id)
//         {
//             return Task.Run(
//                 () =>
//                 {
//                     reservaExcursionCache.TryGetValue(id, out ReservaExcursion r);
//                     return r;
//                 }
//             );
//         }

//         public async Task<Hotel> UpdateAsync(int id, ReservaExcursion r)
//         {
//             this.db.ReservasExcursiones.Update(r);
//             int affected = await this.db.SaveChangesAsync();
//             if (affected == 1)
//             {
//                 return UpdateCache(id, r);
//             }

//             return null;
//         }

//         private ReservaExcursion UpdateCache(int id, ReservaExcursion r)
//         {
//             ReservaExcursion old;
//             if (reservaExcursionCache.TryGetValue(id, out old))
//             {
//                 if (reservaExcursionCache.TryUpdate(id, r, old))
//                 {
//                     return r;
//                 }
//             }
//             return null;
//         }
//     }
// }
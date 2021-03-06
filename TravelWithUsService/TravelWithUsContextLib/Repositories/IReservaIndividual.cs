using System.Threading.Tasks;
using System.Collections.Generic;
using TravelWithUsService.Models;

namespace TravelWithUsService.DBContext.Repositories
{
    public interface IReservaIndividual
    {
        Task<ReservaIndividual> CreateAsync(ReservaIndividual t);
        Task<IEnumerable<ReservaIndividual>> RetrieveAllAsync();
        Task<ReservaIndividual> RetrieveAsync(int key1, int key2, int key3, int key4, int key5);
        Task<ReservaIndividual> UpdateAsync(ReservaIndividual t, int key1, int key2, int key3, int key4, int key5);
        Task<bool?> DeleteAsync(int key1, int key2, int key3, int key4, int key5);
    }
}
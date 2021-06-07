using TravelWithUsService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelWithUsService.DBContext.Repositories
{
    public interface IOferta
    {
        Task<Oferta> CreateAsync(Oferta t);
        Task<IEnumerable<Oferta>> RetrieveAllAsync();
        Task<Oferta> RetrieveAsync(int key1, int key2);
        Task<Oferta> UpdateAsync(Oferta t, int key1, int key2);
        Task<bool?> DeleteAsync(int key1, int key2);
    }
}
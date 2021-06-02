using System.Threading.Tasks;
using System.Collections.Generic;

namespace TravelWithUs.DBContext.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Recibe un <T> y lo agrega a la base de datos.
        /// </summary>
        /// <param name="t">Una instacia de entidad <T></param>
        /// <returns>
        /// En caso de que no exista devuelve un task con la instancia
        /// de la entidad. En caso contrario devuelve null.
        /// </returns>
        Task<T> CreateAsync(T t);
        /// <summary>
        /// Devuelve asincronamente todas las entradas de la entidad <T>
        /// </summary>
        /// <returns>
        /// Devuelve un Task de IEnumerable de la entidad <T>. En caso
        /// de estar vacia devuelve un IEnumerable vacio.
        /// </returns>
        Task<IEnumerable<T>> RetrieveAllAsync();
        Task<T> RetrieveAsync(int id);
        Task<T> UpdateAsync(int id, T t);
        Task<bool?> DeleteAsync(int id);
    }
}
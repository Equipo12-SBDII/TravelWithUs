using System.Threading.Tasks;
using System.Collections.Generic;

namespace TravelWithUs.DBContext.Repositories
{
    public interface IRepositoryReserva<T>
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
        Task<T> RetrieveAsync(int key1, int key2, int key3);
        Task<T> UpdateAsync(T t, int key1, int key2, int key3);
        Task<bool?> DeleteAsync(int key1, int key2, int key3);
    }
}
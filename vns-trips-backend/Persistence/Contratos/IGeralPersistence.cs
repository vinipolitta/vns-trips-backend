using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IGeralPersistence
    {
        //GERAL CRUD
        // GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}

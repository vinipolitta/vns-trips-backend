using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IReviewPersistence
    {
      
        Task<Review[]> GetAllReviewAsync();
        Task<Review> GetReviewByIdAsync(int marketId);
    }
}

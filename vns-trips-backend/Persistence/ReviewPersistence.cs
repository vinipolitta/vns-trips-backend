using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Data;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Persistence
{
    public class ReviewPersistence : IReviewPersistence
    {
        private readonly DataContext _context;

        public ReviewPersistence(DataContext context)
        {
            _context = context;
        }

        public async Task<Review[]> GetAllReviewAsync()
        {
            IQueryable<Review> query = _context.Reviews;
            query = query.OrderBy(m => m.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int marketId)
        {
            IQueryable<Review> query = _context.Reviews;
            query = query.OrderBy(m => m.Id).Where(m => m.Id == marketId);
            return await query.FirstOrDefaultAsync();

        }

    }
}

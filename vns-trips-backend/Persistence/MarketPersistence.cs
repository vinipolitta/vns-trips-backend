using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Data;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Persistence
{
    public class MarketPersistence : IMarketPersistence
    {
        private readonly DataContext _context;

        public MarketPersistence(DataContext context)
        {
            _context = context;
            //SE QUISER USAR NO TRACKING
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Market[]> GetAllMarketsAsync()
        {
            IQueryable<Market> query = _context.Markets;
            query = query.AsNoTracking().OrderBy(m => m.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Market[]> GetAllMarketsByNameAsync(string name)
        {
            IQueryable<Market> query = _context.Markets;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Name.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Market> GetMarketByIdAsync(int marketId)
        {
            IQueryable<Market> query = _context.Markets;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == marketId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<MarketItem> GetMarketItemByIdAsync(int marketId)
        {
            IQueryable<MarketItem> query = _context.MarketItems;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.MarketId == marketId);
            return await query.FirstOrDefaultAsync();
        }
        
    }
}

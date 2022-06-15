using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Data;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Persistence
{
    public class MarketItemPersistence : IMarketItemPersistence
    {
        private readonly DataContext _context;

        public MarketItemPersistence(DataContext context)
        {
            _context = context;
        }

        //Market Items
        public async Task<MarketItem[]> GetAllMarketsItemAsync()
        {
            IQueryable<MarketItem> query = _context.MarketItems;
            query = query.AsNoTracking().OrderBy(m => m.Id);
            return await query.ToArrayAsync();
        }

        public async Task<MarketItem[]> GetAllMarketsItemByNameAsync(string address)
        {
            IQueryable<MarketItem> query = _context.MarketItems;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Name.ToLower().Contains(address.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<MarketItem> GetMarketItemByIdAsync(int marketId)
        {
            IQueryable<MarketItem> query = _context.MarketItems;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == marketId);
            return await query.FirstOrDefaultAsync();
        }


    }
}

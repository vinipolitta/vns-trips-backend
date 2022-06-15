using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IMarketItemPersistence
    {
        //Market Items
        Task<MarketItem[]> GetAllMarketsItemByNameAsync(string address);
        Task<MarketItem[]> GetAllMarketsItemAsync();
        Task<MarketItem> GetMarketItemByIdAsync(int marketId);
    }
}

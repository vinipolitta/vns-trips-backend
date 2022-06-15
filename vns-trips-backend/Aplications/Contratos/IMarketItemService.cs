using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Aplications.Contratos
{
    public interface IMarketItemService
    {
        Task<MarketItem> AddMarketItem(MarketItem model);
        Task<MarketItem> UpdateMarketItem(int marketId, MarketItem model);
        Task<bool> DeleteMarketItem(int marketId);

        Task<MarketItem[]> GetAllMarketsItemAsync();
        Task<MarketItem[]> GetAllMarketsItemByNameAsync(string name);
        Task<MarketItem> GetMarketItemByIdAsync(int marketId);

    }
}

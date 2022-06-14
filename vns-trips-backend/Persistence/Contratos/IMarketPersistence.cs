using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IMarketPersistence
    {
        //Market
        Task<Market[]> GetAllMarketsByNameAsync(string name);
        Task<Market[]> GetAllMarketsAsync();
        Task<Market> GetMarketByIdAsync(int marketId);
        Task<MarketItem> GetMarketItemByIdAsync(int marketId);
    }
}

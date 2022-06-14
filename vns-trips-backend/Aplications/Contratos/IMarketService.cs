using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Aplications.Contratos
{
    public interface IMarketService
    {
        Task<Market> AddMarket(Market model);
        Task<Market> UpdateMarket(int marketId, Market model);
        Task<bool> DeleteMarket(int marketId);

        Task<Market[]> GetAllMarketsAsync();
        Task<Market[]> GetAllMarketsByNameAsync(string name);
        Task<Market> GetMarketByIdAsync(int marketId);
    }
}

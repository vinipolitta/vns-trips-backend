using System;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Aplications
{
    public class MarketItemService: IMarketItemService
    {
        private readonly IGeralPersistence _geralPerisistence;
        private readonly IMarketItemPersistence _marketItemPersistence;

        public MarketItemService(IGeralPersistence geralPerisistence, IMarketItemPersistence marketItemPersistence)
        {
            _geralPerisistence = geralPerisistence;
            _marketItemPersistence = marketItemPersistence;
        }
        public async Task<MarketItem> AddMarketItem(MarketItem model)
        {
            try
            {
                _geralPerisistence.Add<MarketItem>(model);

                if (await _geralPerisistence.SaveChangesAsync())
                {
                    return await _marketItemPersistence.GetMarketItemByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<MarketItem> UpdateMarketItem(int marketId, MarketItem model)
        {
            try
            {
                var market = await _marketItemPersistence.GetMarketItemByIdAsync(marketId);
                if (market == null) return null;

                model.Id = market.Id;

                _geralPerisistence.Update(model);

                if (await _geralPerisistence.SaveChangesAsync())
                {
                    return await _marketItemPersistence.GetMarketItemByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMarketItem(int marketId)
        {
            try
            {
                var market = await _marketItemPersistence.GetMarketItemByIdAsync(marketId);
                if (market == null) throw new Exception("Evento para delete nao foi encontrado");

                _geralPerisistence.Delete<MarketItem>(market);
                return await _geralPerisistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketItem[]> GetAllMarketsItemAsync()
        {
            try
            {
                var market = await _marketItemPersistence.GetAllMarketsItemAsync();
                if (market == null) return null;

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketItem[]> GetAllMarketsItemByNameAsync(string name)
        {
            try
            {
                var market = await _marketItemPersistence.GetAllMarketsItemByNameAsync(name);
                if (market == null) return null;

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketItem> GetMarketItemByIdAsync(int marketId)
        {
            try
            {
                var market = await _marketItemPersistence.GetMarketItemByIdAsync(marketId);
                if (market == null) return null;

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

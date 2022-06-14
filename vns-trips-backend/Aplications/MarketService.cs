using System;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Aplications
{
    public class MarketService : IMarketService
    {
        private readonly IGeralPersistence _geralPerisistence;
        private readonly IMarketPersistence _marketPersistence;

        public MarketService(IGeralPersistence geralPerisistence, IMarketPersistence marketPersistence)
        {
            _geralPerisistence = geralPerisistence;
            _marketPersistence = marketPersistence;
        }
        public async Task<Market> AddMarket(Market model)
        {
            try
            {
                _geralPerisistence.Add<Market>(model);

                if (await _geralPerisistence.SaveChangesAsync())
                {
                    return await _marketPersistence.GetMarketByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<Market> UpdateMarket(int marketId, Market model)
        {
            try
            {
                var market = await _marketPersistence.GetMarketByIdAsync(marketId);
                if (market == null) return null;

                model.Id = market.Id;

                _geralPerisistence.Update(model);

                if (await _geralPerisistence.SaveChangesAsync())
                {
                    return await _marketPersistence.GetMarketByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMarket(int marketId)
        {
            try
            {
                var market = await _marketPersistence.GetMarketByIdAsync(marketId);
                if (market == null) throw new Exception("Evento para delete nao foi encontrado");

                _geralPerisistence.Delete<Market>(market);
                return await _geralPerisistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Market[]> GetAllMarketsAsync()
        {
            try
            {
                var market = await _marketPersistence.GetAllMarketsAsync();
                if (market == null) return null;

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Market[]> GetAllMarketsByNameAsync(string name)
        {
            try
            {
                var market = await _marketPersistence.GetAllMarketsByNameAsync(name);
                if (market == null) return null;

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Market> GetMarketByIdAsync(int marketId)
        {
            try
            {
                var market = await _marketPersistence.GetMarketByIdAsync(marketId);
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

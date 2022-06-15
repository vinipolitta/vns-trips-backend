using System;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Aplications
{
    public class OrderService : IOrderService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IOrderPersistence _orderPersistence;

        public OrderService(IGeralPersistence geralPersistence, IOrderPersistence orderPersistence)
        {
            _geralPersistence = geralPersistence;
            _orderPersistence = orderPersistence;
        }
        public async Task<Order> AddOrder(Order model)
        {
            try
            {
                _geralPersistence.Add<Order>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _orderPersistence.GetOrderByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> UpdateOrder(int marketId, Order model)
        {
            try
            {
                var order = await _orderPersistence.GetOrderByIdAsync(marketId, false);
                if (order == null) return null;

                model.Id = order.Id;

                _geralPersistence.Update(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _orderPersistence.GetOrderByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<bool> DeleteOrder(int marketId)
        {
            try
            {
                var order = await _orderPersistence.GetOrderByIdAsync(marketId, false);
                if (order == null) throw new Exception("Evento para delete nao foi encontrado");

                _geralPersistence.Delete<Order>(order);
                return await _geralPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order[]> GetAllOrdersAsync(bool includeOrderItem = false)
        {
            try
            {
                var order = await _orderPersistence.GetAllOrdersAsync(includeOrderItem);
                if (order == null) return null;

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeOrderItem = false)
        {
            try
            {
                var order = await _orderPersistence.GetAllOrdersByAddressAsync(address ,includeOrderItem);
                if (order == null) return null;

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetOrderByIdAsync(int marketId, bool includeOrderItem = false)
        {
            try
            {
                var order = await _orderPersistence.GetOrderByIdAsync(marketId, includeOrderItem);
                if (order == null) return null;

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}

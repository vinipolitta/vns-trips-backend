using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Aplications.Contratos
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order model);
        Task<Order> UpdateOrder(int marketId, Order model);
        Task<bool> DeleteOrder(int marketId);

        Task<Order[]> GetAllOrdersAsync(bool includeOrderItem = false);
        Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeOrderItem = false);
        Task<Order> GetOrderByIdAsync(int marketId, bool includeOrderItem = false);
    }
}

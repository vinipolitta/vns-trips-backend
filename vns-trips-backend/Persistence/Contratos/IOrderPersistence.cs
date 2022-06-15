using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IOrderPersistence
    {
        //Order
        Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeOrderItem = false);
        Task<Order[]> GetAllOrdersAsync(bool includeOrderItem = false);
        Task<Order> GetOrderByIdAsync(int marketId, bool includeOrderItem = false);
    }
}

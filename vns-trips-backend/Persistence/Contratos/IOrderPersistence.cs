using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Persistence.Contratos
{
    public interface IOrderPersistence
    {
        //Order
        Task<Order[]> GetAllOrdersByAddressAsync(string address);
        Task<Order[]> GetAllOrdersAsync();
        Task<Order> GetOrdersByIdAsync(int marketId);
    }
}

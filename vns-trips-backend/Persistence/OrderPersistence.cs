using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Data;
using vns_trips_backend.Models;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend.Persistence
{
    public class OrderPersistence : IOrderPersistence
    {
        private readonly DataContext _context;

        public OrderPersistence(DataContext context)
        {
            _context = context;
        }
        //ORDERS

        public async Task<Order[]> GetAllOrdersAsync()
        {
            IQueryable<Order> query = _context.Orders;
            query = query.OrderBy(m => m.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetAllOrdersByAddressAsync(string address)
        {
            IQueryable<Order> query = _context.Orders;
            query = query.OrderBy(m => m.Id).Where(m => m.Address.ToLower().Contains(address.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Order> GetOrdersByIdAsync(int marketId)
        {
            IQueryable<Order> query = _context.Orders;
            query = query.OrderBy(m => m.Id).Where(m => m.Id == marketId);
            return await query.FirstOrDefaultAsync();
        }
    }
}

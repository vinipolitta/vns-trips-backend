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

        public async Task<Order[]> GetAllOrdersAsync(bool includeOrderItem = false)
        {
            IQueryable<Order> query = _context.Orders.Include(o => o.OrderItems);

            if (includeOrderItem)
            {
                query = query.Include(order => order.OrderItems);
            }
            query = query.AsNoTracking().OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeOrderItem)
        {
            IQueryable<Order> query = _context.Orders.Include(o => o.OrderItems);
            if (includeOrderItem)
            {
                query = query.Include(order => order.OrderItems);
            }
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Address.ToLower().Contains(address.ToLower())); ;

            return await query.ToArrayAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int marketId, bool includeOrderItem)
        {
            IQueryable<Order> query = _context.Orders.Include(o => o.OrderItems);
            if (includeOrderItem)
            {
                query = query.Include(order => order.OrderItems);
            }
            query = query.AsNoTracking().OrderBy(o => o.Id).Where(o => o.Id == marketId); ;

            return await query.FirstOrDefaultAsync();
        }
    }
}

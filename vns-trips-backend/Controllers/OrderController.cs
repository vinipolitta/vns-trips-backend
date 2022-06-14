using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using vns_trips_backend.Data;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Orders;
        }


        [HttpGet("{id}")]
        public IEnumerable<Order> GetById(int id)
        {
            return _context.Orders.Where(orders => orders.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "valeu post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"valeu put: {id}";

        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"valeu del: {id}";
        }
    }
}

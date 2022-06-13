using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Data;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketController : ControllerBase
    {
     
        public DataContext _context { get; }

        public MarketController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Market> Get()
        {
            return _context.Markets;
        }

        [HttpGet("{id}")]
        public IEnumerable<Market> GetById(int id)
        {
            return _context.Markets.Where(market => market.Id == id);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketController : ControllerBase
    {
        public IEnumerable<Market> _market = new Market[]
            {
                new Market()
                {
                    Id= 1,
                    Name= "Bread & Bakery",
                    Category= "Bakery",
                    DeliveryEstimate= "25m",
                    Rating = 4.9,
                    ImagePath= "assets/img/restaurants/breadbakery.png",
                    About = "A Bread & Brakery tem 40 anos de mercado. Fazemos os melhores doces e pães. Compre e confira.",
                    Hours = "Funciona de segunda à sexta, de 8h às 23h",
                },
                new Market()
                {
                    Id= 2,
                    Name= "Burger House",
                    Category= "Hamburgers",
                    DeliveryEstimate= "100m",
                    Rating = 3.5,
                    ImagePath= "assets/img/restaurants/burgerhouse.png",
                    About = "40 anos se especializando em trash food.",
                    Hours = "Funciona todos os dias, de 10h às 22h"
                }
            };
        public MarketController()
        {

        }

        [HttpGet]
        public IEnumerable<Market> Get()
        {
            return _market;
        }

        [HttpGet("{id}")]
        public IEnumerable<Market> GetById(int id)
        {
            return _market.Where(market => market.Id == id);
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

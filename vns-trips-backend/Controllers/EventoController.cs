using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using System.Collections.Generic;
using System.Linq;
using vns_trips_backend.Data;

namespace vns_trips_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;

        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
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

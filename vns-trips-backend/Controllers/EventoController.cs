using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _events = new Evento[]
        {
            new Evento()
            {
                EventoId = 1,
                Local = "Belo Horizonte",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "ANgular 12",
                QtdPessoas = "250",
                Lote = "1 lote",
                ImageURL = "teste.img",
            },
            new Evento()
            {
                EventoId = 2,
                Local = "Sao Paulo",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "ANgular 9",
                QtdPessoas = "150",
                Lote = "2 lote",
                ImageURL = "teste.img",
            },
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _events;

        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _events.Where(evento => evento.EventoId == id);
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

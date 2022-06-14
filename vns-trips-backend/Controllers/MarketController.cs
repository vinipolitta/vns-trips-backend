using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Data;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var markets = await _marketService.GetAllMarketsAsync();
                if (markets == null) return NotFound("Nenhum mercado encontrado");

                return Ok(markets);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar mercado. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var market = await _marketService.GetMarketByIdAsync(id);
                if (market == null) return NotFound("Marcado por id nao encontrado");

                return Ok(market);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar mercado. Erro: {ex.Message}");
            }
        }

        //[HttpGet("{id}/market-itens")]
        //public async Task<ActionResult> GetByName(int id)
        //{
        //    try
        //    {
        //        var market = await _marketService.GetMarketByIdAsync(id);
        //        if (market == null) return NotFound("Item do mercado por ID nao encontrado");

        //        return Ok(market);

        //    }
        //    catch (Exception ex)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar mercado. Erro: {ex.Message}");
        //    }
        //}

        //[HttpGet("{marketId}/markertsItems")]
        //public IEnumerable<MarketItem> GetByIdItem(int marketId)
        //{
        //    return _context.MarketItems.Where(mktItem => mktItem.MarketId == marketId);
        //}

        //[HttpGet("{marketId}/reviews")]
        //public IEnumerable<MarketItem> GetByIdIReview(int marketId)
        //{
        //    return _context.MarketItems.Where(mktItem => mktItem.MarketId == marketId);
        //}


        [HttpPost]
        public async Task<IActionResult> Post(Market model)
        {
            try
            {
                var market = await _marketService.AddMarket(model);
                if (market == null) return BadRequest("Erro ao tentar adicionar MARKET");

                return Ok(market);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar mercado. Erro: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Market model)
        {
            try
            {
                var market = await _marketService.UpdateMarket(id, model);
                if (market == null) return BadRequest("Erro ao tentar atualizar MARKET");

                return Ok(market);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Atualizar mercado. Erro: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _marketService.DeleteMarket(id) ?
                    Ok("Deletado") :
                    BadRequest("Evento nao deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar mercado. Erro: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketItemController : ControllerBase
    {
        private readonly IMarketItemService _marketItemService;

        public MarketItemController(IMarketItemService marketItemService)
        {
            _marketItemService = marketItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var markets = await _marketItemService.GetAllMarketsItemAsync();
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
                var market = await _marketItemService.GetMarketItemByIdAsync(id);
                if (market == null) return NotFound("Marcado por id nao encontrado");

                return Ok(market);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar mercado. Erro: {ex.Message}");
            }
        }


        


        [HttpPost]
        public async Task<IActionResult> Post(MarketItem model)
        {
            try
            {
                var market = await _marketItemService.AddMarketItem(model);
                if (market == null) return BadRequest("Erro ao tentar adicionar MARKET");

                return Ok(market);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar mercado. Erro: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MarketItem model)
        {
            try
            {
                var market = await _marketItemService.UpdateMarketItem(id, model);
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
                return await _marketItemService.DeleteMarketItem(id) ?
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

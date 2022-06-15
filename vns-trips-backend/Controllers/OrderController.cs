using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Data;
using vns_trips_backend.Models;

namespace vns_trips_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync(true);
                if (orders == null) return NotFound("Nenhuma Order encontrada");
                return Ok(orders);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar orders. ERRO {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id, false);
                if (order == null) return NotFound("Nenhuma Order encontrada");
                return Ok(order);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar orders. ERRO {ex.Message}");
            }
        }

        [HttpGet("{address}/order-address")]
        public async Task<IActionResult> GetByTema(string address)
        {
            try
            {
                var order = await _orderService.GetAllOrdersByAddressAsync(address, true);
                if (order == null) return NotFound("Nenhuma Order encontrada");
                return Ok(order);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar orders. ERRO {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order model)
        {
            try
            {
                var order = await _orderService.AddOrder(model);
                if (order == null) return BadRequest("Erro ao tentar add Order");
                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar add orders. ERRO {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Order model)
        {
            try
            {
                var order = await _orderService.UpdateOrder(id, model);
                if (order == null) return BadRequest("Erro ao tentar add Order");
                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar orders. ERRO {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _orderService.DeleteOrder(id) ?
                    Ok("Deletado") :
                    BadRequest("Evento nao deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar order. Erro: {ex.Message}");
            }
        }
    }
}

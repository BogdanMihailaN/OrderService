using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Models;
using OrderService.Services.Order;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderModel orderDto)
        {
            var orderId = await _orderService.CreateOrderAsync(orderDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}

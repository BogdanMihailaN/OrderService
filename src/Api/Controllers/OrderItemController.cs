using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Models;
using OrderService.Services.OrderItem;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemAsync(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItemAsync([FromBody] OrderItemModel orderItemDto)
        {
            var orderItemId = await _orderItemService.CreateOrderItemAsync(orderItemDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}

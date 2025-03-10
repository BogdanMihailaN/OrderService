using OrderService.Domain.Models;
using OrderService.Repositories.OrderItem;

namespace OrderService.Services.OrderItem
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItemModel> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            return orderItem;
        }

        public async Task<IEnumerable<OrderItemModel>> GetAllOrderItemsAsync()
        {
            var ordersItem = await _orderItemRepository.GetAllOrderItemsAsync();
            return ordersItem;
        }

        public async Task<int> CreateOrderItemAsync(OrderItemModel orderItem)
        {
            await _orderItemRepository.AddOrderItemAsync(orderItem);
            return orderItem.Id;
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteOrderItemAsync(id);
        }
    }
}

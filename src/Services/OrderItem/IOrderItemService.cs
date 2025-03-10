using OrderService.Domain.Models;

namespace OrderService.Services.OrderItem
{
    public interface IOrderItemService
    {
        Task<OrderItemModel> GetOrderItemByIdAsync(int id);
        Task<IEnumerable<OrderItemModel>> GetAllOrderItemsAsync();
        Task<int> CreateOrderItemAsync(OrderItemModel orderItemDto);
        Task DeleteOrderItemAsync(int id);
    }
}

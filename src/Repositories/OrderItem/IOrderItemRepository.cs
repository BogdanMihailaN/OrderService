using OrderService.Domain.Models;

namespace OrderService.Repositories.OrderItem
{
    public interface IOrderItemRepository
    {
        Task<OrderItemModel> GetOrderItemByIdAsync(int id);
        Task<IEnumerable<OrderItemModel>> GetAllOrderItemsAsync();
        Task AddOrderItemAsync(OrderItemModel orderItem);
        Task DeleteOrderItemAsync(int id);
    }
}

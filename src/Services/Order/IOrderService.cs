using OrderService.Domain.Models;

namespace OrderService.Services.Order
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task<int> CreateOrderAsync(OrderModel orderDto);
        Task DeleteOrderAsync(int id);
    }
}

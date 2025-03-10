using OrderService.Domain.Models;

namespace OrderService.Repositories.Order
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task AddOrderAsync(OrderModel order);
        Task DeleteOrderAsync(int id);
    }
}

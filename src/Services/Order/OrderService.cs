using OrderService.Domain.Models;
using OrderService.Repositories.Order;

namespace OrderService.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return orders;
        }

        public async Task<int> CreateOrderAsync(OrderModel order)
        {
            await _orderRepository.AddOrderAsync(order);
            return order.Id;
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}

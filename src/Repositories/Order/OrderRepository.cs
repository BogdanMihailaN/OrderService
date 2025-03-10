using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Models;
using OrderService.Infrastructure;

namespace OrderService.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderServiceDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(OrderServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var orderModel = _mapper.Map<OrderModel>(order);
            return orderModel;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            var orderModels = _mapper.Map<List<OrderModel>>(orders);
            return orderModels;
        }

        public async Task AddOrderAsync(OrderModel order)
        {
            var orderEntity = _mapper.Map<Domain.Entities.Order>(order);
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderModel = await GetOrderByIdAsync(id);
            var order = _mapper.Map<Domain.Entities.Order>(orderModel);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}

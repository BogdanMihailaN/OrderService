using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Models;
using OrderService.Infrastructure;

namespace OrderService.Repositories.OrderItem
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderServiceDbContext _context;
        private readonly IMapper _mapper;

        public OrderItemRepository(OrderServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderItemModel> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var orderItemModel = _mapper.Map<OrderItemModel>(orderItem);
            return orderItemModel;
        }

        public async Task<IEnumerable<OrderItemModel>> GetAllOrderItemsAsync()
        {
            var orderItems = await _context.OrderItems.ToListAsync();
            var orderItemModels = _mapper.Map<List<OrderItemModel>>(orderItems);
            return orderItemModels;
        }

        public async Task AddOrderItemAsync(OrderItemModel orderItem)
        {
            var orderItemEntity = _mapper.Map<Domain.Entities.OrderItem>(orderItem);
            await _context.OrderItems.AddAsync(orderItemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var orderItemModel = await GetOrderItemByIdAsync(id);
            var orderItem = _mapper.Map<Domain.Entities.OrderItem>(orderItemModel);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}

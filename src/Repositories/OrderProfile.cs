using AutoMapper;
using OrderService.Domain.Models;

namespace OrderService.Repositories
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Entities.Order, OrderModel>();
            CreateMap<OrderModel, Domain.Entities.Order>();
            CreateMap<OrderItemModel, Domain.Entities.OrderItem>();
            CreateMap<Domain.Entities.OrderItem, OrderItemModel>();
        }
    }
}

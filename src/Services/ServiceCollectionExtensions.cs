using Microsoft.Extensions.DependencyInjection;
using OrderService.Services.Order;
using OrderService.Services.OrderItem;

namespace OrderService.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, Order.OrderService>();
            services.AddTransient<IOrderItemService, OrderItemService>();

            return services;
        }
    }
}

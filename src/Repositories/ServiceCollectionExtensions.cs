using Microsoft.Extensions.DependencyInjection;
using OrderService.Repositories.Order;
using OrderService.Repositories.OrderItem;

namespace OrderService.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();

            return services;
        }
    }
}

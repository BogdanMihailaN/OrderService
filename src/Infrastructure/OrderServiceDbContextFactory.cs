using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderService.Infrastructure
{
    public class OrderServiceDbContextFactory : IDesignTimeDbContextFactory<OrderServiceDbContext>
    {
        public OrderServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderServiceDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=OrderServiceDb;TrustServerCertificate=True;Integrated Security=True;");

            return new OrderServiceDbContext(optionsBuilder.Options);
        }
    }
}

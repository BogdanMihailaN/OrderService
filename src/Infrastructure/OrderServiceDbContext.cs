using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure
{
    public class OrderServiceDbContext : DbContext
    {
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2025, 3, 7),
                    UserId = 1,
                    TotalAmount = 99.99m
                }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Price = 49.99m,
                    Quantity = 1
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 1,
                    Price = 50.00m,
                    Quantity = 1
                }
            );
        }
    }
}

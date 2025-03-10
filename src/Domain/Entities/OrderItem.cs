namespace OrderService.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Relație cu Order (multe OrderItems pentru o singură comandă)
        public Order Order { get; set; }
    }
}

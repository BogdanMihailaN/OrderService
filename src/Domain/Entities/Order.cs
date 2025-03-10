namespace OrderService.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }

        // Relație 1:n cu OrderItem
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

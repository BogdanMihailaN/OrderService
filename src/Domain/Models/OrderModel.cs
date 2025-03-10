namespace OrderService.Domain.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

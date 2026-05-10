namespace Nexus.Core.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
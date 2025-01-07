
namespace StockTrackingApp.Dtos.Orders
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public string OrderStatus { get; set; }
    }
}

using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Dtos.Orders
{
    public class OrderCreateDto
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public string OrderStatus { get; set; }
        public List<OrderDetailCreateDto> OrderDetails { get; set; }
    }
}

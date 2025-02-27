using StockTrackingApp.Dtos.OrderDetails;
namespace StockTrackingApp.Dtos.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new();

        public decimal TotalPriceExcludingVAT => OrderDetails.Sum(d => d.TotalPriceExcludingVAT);
        public decimal VATAmount => OrderDetails.Sum(d => d.VATAmount);
        public decimal TotalPriceIncludingVAT => OrderDetails.Sum(d => d.TotalPriceIncludingVAT);
    }
}


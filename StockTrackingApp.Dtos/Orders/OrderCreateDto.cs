using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Dtos.Orders
{
    public class OrderCreateDto
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalExcludingVATAmount { get; set; }
        public decimal TotalVATAmount { get; set; }

        public string OrderNo { get; set; }
        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetailCreateDto> OrderDetailDtos { get; set; } = new();
    }
}

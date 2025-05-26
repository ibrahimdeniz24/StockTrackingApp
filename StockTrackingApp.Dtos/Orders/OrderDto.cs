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

        public string CustomerName { get; set; } 
        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new();

    }
}


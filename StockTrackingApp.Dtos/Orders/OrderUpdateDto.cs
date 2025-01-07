using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Dtos.Orders
{
    internal class OrderUpdateDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetailUpdateDto> OrderDetails { get; set; }
    }
}

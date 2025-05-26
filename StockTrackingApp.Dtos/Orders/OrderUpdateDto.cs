using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Dtos.Orders
{
    public class OrderUpdateDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalExcludingVATAmount { get; set; }  //Siparişin Toplam tutarı KDV hari.ç
        public decimal TotalVATAmount { get; set; } //Siparişin toplam KDV tutarı
        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetailUpdateDto> OrderDetailDtos { get; set; } = new();
    }
}

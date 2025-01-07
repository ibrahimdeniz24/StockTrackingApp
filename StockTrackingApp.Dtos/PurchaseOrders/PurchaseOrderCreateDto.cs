using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Dtos.PurchaseOrders
{
    public class PurchaseOrderCreateDto
    {
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public Guid SupplierId { get; set; }

        public  IEnumerable<PurchaseOrderDetailCreateDto> PurchaseOrderDetails { get; set; }
    }
}

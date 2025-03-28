

using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Dtos.PurchaseOrders
{
    public class PurchaseOrderUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; }
        public DateTime DeliveryDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TotalExcludingVATAmount { get; set; }
        public decimal TotalVATAmount { get; set; }

        public string Description { get; set; }

        public Guid SupplierId { get; set; }

        public IEnumerable<PurchaseOrderDetailUpdateDto> PurchaseOrderDetails { get; set; }
    }
}

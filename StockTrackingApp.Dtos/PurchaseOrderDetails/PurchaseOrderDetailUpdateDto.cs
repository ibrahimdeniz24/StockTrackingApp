
namespace StockTrackingApp.Dtos.PurchaseOrderDetails
{
    public class PurchaseOrderDetailUpdateDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; } // Miktar
        public decimal UnitPrice { get; set; } // Birim Fiyat

        public decimal TotalPriceExcludingVAT { get; set; }
        public decimal VATAmount { get; set; }
        public decimal TotalPriceIncludingVAT { get; set; }
        public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }
    }

}

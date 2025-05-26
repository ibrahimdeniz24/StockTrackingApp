using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs
{
    public class AdminOrderDetailUpdateVM
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public VatRate VATRate { get; set; }

        public decimal TotalPriceExcludingVAT { get; set; } // KDV'siz toplam
        public decimal VATAmount { get; set; } // KDV tutarı
        public decimal TotalPriceIncludingVAT { get; set; } // KDV dahil toplam
    }
}

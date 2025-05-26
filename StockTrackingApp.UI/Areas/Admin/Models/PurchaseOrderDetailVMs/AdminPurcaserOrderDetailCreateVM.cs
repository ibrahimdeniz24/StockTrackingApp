using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.UI.Areas.Admin.Models.PurchaseOrderDetailVMs
{
    public class AdminPurcaserOrderDetailCreateVM
    {
        public int Quantity { get; set; } // Miktar
        public decimal UnitPrice { get; set; } // Birim Fiyat

        public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }

        public VatRate VATRate { get; set; } //KDV Oranı
        public decimal TotalPriceExcludingVAT { get; set; } // KDV'siz toplam
        public decimal VATAmount { get; set; } // KDV tutarı
        public decimal TotalPriceIncludingVAT { get; set; } // KDV dahil toplam
    }
}

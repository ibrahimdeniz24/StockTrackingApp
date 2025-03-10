

using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.Entities.DbSets
{
    public class OrderDetail :AuditableEntity
    {
        public Guid OrderId { get; set; } // Sipariş ID (FK)
        public virtual Order Order { get; set; } // Sipariş İlişkisi
        public Guid StockId { get; set; } // Stock ID (FK)
        public virtual Stock Stock { get; set; } // Stock İlişkisi
        public int Quantity { get; set; } // Miktar
        public decimal UnitPrice { get; set; } // Birim Fiyat

        public VatRate VATRate { get; set; } //KDV Oranı
        public decimal TotalPriceExcludingVAT { get; set; } // KDV'siz toplam
        public decimal VATAmount { get; set; } // KDV tutarı
        public decimal TotalPriceIncludingVAT { get; set; } // KDV dahil toplam


    }
}



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

        public VatRate VATRate { get; set; }
        public decimal TotalPriceExcludingVAT => UnitPrice * Quantity; // KDV'siz toplam
        public decimal VATAmount => TotalPriceExcludingVAT * ((decimal)VATRate / 100); // KDV tutarı
        public decimal TotalPriceIncludingVAT => TotalPriceExcludingVAT + VATAmount; // KDV dahil toplam


    }
}

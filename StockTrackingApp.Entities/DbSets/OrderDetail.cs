

namespace StockTrackingApp.Entities.DbSets
{
    public class OrderDetail :AuditableEntity
    {
        public Guid OrderId { get; set; } // Sipariş ID (FK)
        public virtual Order Order { get; set; } // Sipariş İlişkisi
        public Guid ProductId { get; set; } // Ürün ID (FK)
        public virtual Product Product { get; set; } // Ürün İlişkisi
        public Guid WarehouseId { get; set; }

        public virtual Warehouse warehouse { get; set; }

        public int Quantity { get; set; } // Miktar
        public decimal UnitPrice { get; set; } // Birim Fiyat

    }
}

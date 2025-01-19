

namespace StockTrackingApp.Entities.DbSets
{
    public class Product :AuditableEntity
    {
        public Product()
        {
            Stocks = new HashSet<Stock>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductSuppliers = new HashSet<ProductSupplier>();
        }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public virtual Category Category { get; set; } // Kategori İlişkisi
        public virtual ICollection<Stock> Stocks { get; set; } 
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Sipariş Detayları
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } // Sipariş Detayları
        public virtual ICollection<ProductSupplier>  ProductSuppliers { get; set; }
    }
}



namespace StockTrackingApp.Entities.DbSets
{
    public class Product : AuditableEntity
    {
        public Product()
        {
            Stocks = new HashSet<Stock>();
        }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public virtual Category Category { get; set; } // Kategori İlişkisi

        public byte[] ProductImage { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
       
    }
}



namespace StockTrackingApp.Dtos.Products
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public Guid CategoryId { get; set; } // Kategori ID
        public string CategoryName { get; set; } // Kategori Adı
        public Guid SupplierId { get; set; } // Kategori ID

        public byte[] ProductImage { get; set; }
        public string SupplierName { get; set; } // Kategori Adı
    }
}

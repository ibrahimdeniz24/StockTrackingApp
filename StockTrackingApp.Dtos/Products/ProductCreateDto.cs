
namespace StockTrackingApp.Dtos.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public string CategoryName { get; set; }
        public Guid SupplierId { get; set; }

        public byte[] ProductImage { get; set; }

        public string SupplierName { get; set; }

    }
}
 
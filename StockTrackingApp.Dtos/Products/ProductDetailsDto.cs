

namespace StockTrackingApp.Dtos.Products
{
    public class ProductDetailsDto
    {
        public Guid Id { get; set; } // Ürün ID
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public string CategoryName { get; set; }
        public VatRate VatRate { get; set; }
        public Guid SupplierId { get; set; }
        public byte[] ProductImage { get; set; }
        public string SupplierName { get; set; }
    }
}


namespace StockTrackingApp.Dtos.Products
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; } // Ürün ID
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public Guid SupplierId { get; set; }

        public byte[] ProductImage { get; set; }

    }

}

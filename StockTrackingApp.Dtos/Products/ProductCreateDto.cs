
namespace StockTrackingApp.Dtos.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public byte[] ProductImage { get; set; } //Ürün Görseli

    }
}
 
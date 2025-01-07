

using StockTrackingApp.Dtos.ProductSuppliers;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace StockTrackingApp.Dtos.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public Guid CategoryId { get; set; } // Kategori ID (FK)
        public string CategoryName { get; set; }

        public IEnumerable<ProductSupplierCreateDto> ProductSuppliers { get; set; }   

    }
}
 
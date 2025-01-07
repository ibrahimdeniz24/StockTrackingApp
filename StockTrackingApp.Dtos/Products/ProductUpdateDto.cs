using StockTrackingApp.Dtos.ProductSuppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Products
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; } // Ürün ID
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public Guid CategoryId { get; set; } // Kategori ID

        public IEnumerable<ProductSupplierUpdateDto> ProductSuppliers { get; set; }
    }

}

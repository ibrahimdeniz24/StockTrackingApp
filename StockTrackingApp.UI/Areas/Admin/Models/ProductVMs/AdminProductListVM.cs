using System.Web.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public decimal Price { get; set; } // Fiyat
        public List<SelectListItem>? Categories { get; set; } // Kategori Adı
        public List<SelectListItem>? Suppliers { get; set; } // Kategori Adı
    }
}

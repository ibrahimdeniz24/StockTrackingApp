using StockTrackingApp.Entities.Enums;
using System.Web.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public VatRate VatRate { get; set; }
        public byte[] ProductImage { get; set; }
        public List<SelectListItem>? Categories { get; set; } // Kategori Adı
        public string CategoryName { get; set; }

        public Guid CategoryId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductUpdateVM
    {
        public Guid Id { get; set; }
       
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SKU zorunludur.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        public Guid SupplierId { get; set; }
    }
}

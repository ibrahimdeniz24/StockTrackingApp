using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductCreateVM
    {
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SKU zorunludur.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        public Guid SupplierId { get; set; }

        public byte[] ProductImage { get; set; }

        public IFormFile? NewPicture { get; set; }

        public VatRate VatRate { get; set; }
    }
}

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

        [Required(ErrorMessage = "SKU alanı zorunludur.")]
        [MaxLength(13, ErrorMessage = "SKU en fazla 13 karakter olmalıdır.")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "SKU yalnızca rakamlardan oluşmalıdır.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public Guid CategoryId { get; set; }



        public byte[] ProductImage { get; set; }

        public IFormFile? NewPicture { get; set; }

        public VatRate VatRate { get; set; }
    }
}

using StockTrackingApp.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductUpdateVM
    {
        public Guid Id { get; set; }
       
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SKU alanı zorunludur.")]
        [MaxLength(13, ErrorMessage = "SKU en fazla 13 karakter olmalıdır.")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "SKU yalnızca rakamlardan oluşmalıdır.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        public Guid SupplierId { get; set; }

        public byte[] ProductImage { get; set; }

        public IFormFile? NewPicture { get; set; }
    }
}

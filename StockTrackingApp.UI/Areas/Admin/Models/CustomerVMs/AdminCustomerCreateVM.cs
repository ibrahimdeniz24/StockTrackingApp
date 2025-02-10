using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.CustomerVMs
{
    public class AdminCustomerCreateVM
    {
        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        public string CompanyName { get; set; } // Tedarikçi Adı

        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vergi numarası zorunludur.")]
        [StringLength(10, ErrorMessage = "Vergi numarası 10 karakter olmalıdır.")]
        public string TaxNo { get; set; }
    }
}

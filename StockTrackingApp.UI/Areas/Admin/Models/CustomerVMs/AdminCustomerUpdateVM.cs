using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.CustomerVMs
{
    public class AdminCustomerUpdateVM
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }

        public string Adress { get; set; }
        
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^(\d{10,11})$", ErrorMessage = "Telefon numarası 10 veya 11 haneli olmalıdır ve sadece rakam içermelidir.")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
    }
}

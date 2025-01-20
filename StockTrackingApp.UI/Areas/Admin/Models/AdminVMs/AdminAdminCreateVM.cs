using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.AdminVMs
{
    public class AdminAdminCreateVM
    {
        [Display(Name = "First_Name")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last_Name")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Lütfen cinsiyet seçiniz.")]
        [Display(Name = "Gender")]
        public bool Gender { get; set; }
  
        [Display(Name = "Profile_Image")]
        public IFormFile? NewImage { get; set; }

        [Display(Name = "OtherEmails")]
        public string? OtherEmails { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.ApiUserVMs
{
    public class AdminApiUserCreateVM
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
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen cinsiyet seçiniz.")]
        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Display(Name = "Profile_Image")]
        public IFormFile? NewImage { get; set; }
    }
}

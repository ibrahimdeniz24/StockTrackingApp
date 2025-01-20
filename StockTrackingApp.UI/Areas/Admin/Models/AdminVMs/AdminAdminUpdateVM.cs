using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.AdminVMs
{
    public class AdminAdminUpdateVM
    {
        public Guid Id { get; set; }

        [Display(Name = "First_Name")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string FirstName { get; set; }

        [Display(Name = "Last_Name")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string LastName { get; set; }
        public string Image { get; set; }

        [Display(Name = "Profile_Image")]
        public IFormFile? NewImage { get; set; }
        public byte[]? OriginalImage { get; set; } //Detaylarda fotoyu görüntülerken db deki fotoyu bu prop aracılığıyla alacak
        public bool RemoveImage { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public bool Gender { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name = "OtherEmails")]
        public List<string>? OtherEmails { get; set; }
  
    }
}

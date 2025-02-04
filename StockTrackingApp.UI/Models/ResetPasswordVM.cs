using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Models
{
    public class ResetPasswordVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

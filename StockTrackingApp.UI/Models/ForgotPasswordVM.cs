using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Models
{
    public class ForgotPasswordVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}

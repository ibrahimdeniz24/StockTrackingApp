using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.Entities.Enums
{
    public enum VatRate
    {
        [Display(Name = "%1 KDV")]
        One = 1,  // %1 KDV

        [Display(Name = "%10 KDV")]
        Ten = 10, // %10 KDV

        [Display(Name = "%20 KDV")]
        Twenty = 20 // %20 KDV
    }
}

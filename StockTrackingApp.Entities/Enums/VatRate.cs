using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.Entities.Enums
{
    public enum VatRate
    {
        [Display(Name = "%1")]
        One = 1,  // %1 KDV

        [Display(Name = "%10")]
        Ten = 10, // %10 KDV

        [Display(Name = "%20")]
        Twenty = 20 // %20 KDV
    }
}

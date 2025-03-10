using FluentValidation;
using StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs;

namespace StockTrackingApp.UI.FluentValidators.SupplierValidators
{
    public class SupplierCreateValidator : AbstractValidator<AdminSupplierCreateVM>
    {
        public SupplierCreateValidator()
        {
            
        }
    }
}

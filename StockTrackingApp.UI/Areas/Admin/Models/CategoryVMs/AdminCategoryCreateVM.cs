using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs
{
    public class AdminCategoryCreateVM
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        public string CategoryName { get; set; }

        public string? Description { get; set; }

    }
}

namespace StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs
{
    public class AdminCategoryVM
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}

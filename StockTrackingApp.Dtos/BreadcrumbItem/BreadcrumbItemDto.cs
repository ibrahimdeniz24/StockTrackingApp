
namespace StockTrackingApp.Dtos.BreadcrumbItem
{
    public class BreadcrumbItemDto
    {
        public string Title { get; set; } // Örn: Eğitmenler
        public string Url { get; set; }   // Örn: /Admin/Trainer
        public bool IsActive { get; set; } // Aktif olan sayfa için true
    }
}

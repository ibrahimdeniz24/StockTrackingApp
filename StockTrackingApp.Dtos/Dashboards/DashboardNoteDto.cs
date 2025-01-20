

namespace StockTrackingApp.Dtos.Dashboards
{
    public class DashboardNoteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public DateTime? End { get; set; }
        public string Content { get; set; }
    }
}

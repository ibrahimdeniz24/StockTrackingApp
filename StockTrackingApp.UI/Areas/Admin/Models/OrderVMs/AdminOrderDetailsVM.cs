using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.UI.Areas.Admin.Models.OrderVMs
{
    public class AdminOrderDetailsVM
    {
        public Guid Id  { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}

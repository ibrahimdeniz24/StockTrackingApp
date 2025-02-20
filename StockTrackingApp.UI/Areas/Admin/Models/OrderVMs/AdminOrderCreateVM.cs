using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs;

namespace StockTrackingApp.UI.Areas.Admin.Models.OrderVMs
{
    public class AdminOrderCreateVM
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<AdminOrderDetailCreateVM> AdminOrderDetailCreateVMs { get; set; }
    }
}

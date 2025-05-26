using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs;

namespace StockTrackingApp.UI.Areas.Admin.Models.OrderVMs
{
    public class AdminOrderUpdateVM
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalExcludingVATAmount { get; set; }  //Siparişin Toplam tutarı KDV hari.ç
        public decimal TotalVATAmount { get; set; } //Siparişin toplam KDV tutarı
        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<AdminOrderDetailUpdateVM> AdminOrderDetailUpdateVMs { get; set; }
    }
}

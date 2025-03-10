using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs;

namespace StockTrackingApp.UI.Areas.Admin.Models.OrderVMs
{
    public class AdminOrderCreateVM
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; } //Siparişin Toplam tutarı
        public decimal TotalExcludingVATAmount { get; set; }  //Siparişin Toplam tutarı KDV hari.ç
        public decimal TotalVATAmount { get; set; } //Siparişin toplam KDV tutarı
        public string Description { get; set; }

        public string OrderNo { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<AdminOrderDetailCreateVM> AdminOrderDetailCreateVMs { get; set; }
    }
}

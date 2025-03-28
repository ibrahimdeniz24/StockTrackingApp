using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.PurchaseOrderDetailVMs;

namespace StockTrackingApp.UI.Areas.Admin.Models.PurchaseOrderVMs
{
    public class AdminPurchaseOrderCreateVM
    {
        public Guid SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string OrderNo { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPriceExcludingVAT { get; set; }
        public decimal VATAmount { get; set; }
        public decimal TotalPriceIncludingVAT { get; set; }

        public string Description { get; set; }

        public ICollection<AdminPurcaserOrderDetailCreateVM> AdminPurcaserOrderDetailCreateVMs { get; set; }
    }
}

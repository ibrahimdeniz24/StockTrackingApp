
using StockTrackingApp.Dtos.PurchaseOrders;

namespace StockTrackingApp.Business.Profiles
{
    public class PurchaseOrderProfile :Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrder,PurchaseOrderCreateDto>();
            CreateMap<PurchaseOrder,PurchaseOrderDto>();
            CreateMap<PurchaseOrder,PurchaseOrderListDto>();
            CreateMap<PurchaseOrder,PurchaseOrderUpdateDto>();

        }
    }
}

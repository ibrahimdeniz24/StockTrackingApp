

using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Business.Profiles
{
    public class PurchaseOrderDetailProfile :Profile
    {
        public PurchaseOrderDetailProfile()
        {
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailCreateDto>();
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailDto>();
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailListDto>();
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailUpdateDto>();
        }
    }
}

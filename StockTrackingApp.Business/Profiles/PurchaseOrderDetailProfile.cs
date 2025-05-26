

using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Business.Profiles
{
    public class PurchaseOrderDetailProfile :Profile
    {
        public PurchaseOrderDetailProfile()
        {
            CreateMap<PurchaseOrderDetailCreateDto, PurchaseOrderDetail>();
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailDto>();
            CreateMap<PurchaseOrderDetail,PurchaseOrderDetailListDto>();
            CreateMap<PurchaseOrderDetailUpdateDto, PurchaseOrderDetail>();
        }
    }
}

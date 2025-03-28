
using StockTrackingApp.Dtos.PurchaseOrders;

namespace StockTrackingApp.Business.Profiles
{
    public class PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrder, PurchaseOrderCreateDto>();
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrder, PurchaseOrderUpdateDto>();
            CreateMap<PurchaseOrder, PurchaseOrderListDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(opt => opt.Supplier.CompanyName));

        }
    }
}


using StockTrackingApp.Dtos.PurchaseOrders;

namespace StockTrackingApp.Business.Profiles
{
    public class PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrderCreateDto, PurchaseOrder>();
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrderUpdateDto, PurchaseOrder>();
            CreateMap<PurchaseOrder, PurchaseOrderListDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(opt => opt.Supplier.CompanyName));

        }
    }
}

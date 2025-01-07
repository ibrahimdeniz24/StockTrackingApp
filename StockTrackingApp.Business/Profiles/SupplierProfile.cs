
using StockTrackingApp.Dtos.Suppliers;

namespace StockTrackingApp.Business.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier,SupplierCreateDto>();
            CreateMap<Supplier,SupplierDetailDto>();
            CreateMap<Supplier,SupplierDto>();
            CreateMap<Supplier,SupplierListDto>();

        }
    }
}


using StockTrackingApp.Dtos.Suppliers;

namespace StockTrackingApp.Business.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<Supplier,SupplierDetailsDto>();
            CreateMap<Supplier,SupplierDto>();
            CreateMap<Supplier,SupplierListDto>();
            CreateMap<SupplierUpdateDto, Supplier>();

        }
    }
}

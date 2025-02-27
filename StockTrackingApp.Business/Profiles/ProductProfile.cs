
using StockTrackingApp.Dtos.Products;

namespace StockTrackingApp.Business.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDetailsDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductListDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));
        }
    }
}

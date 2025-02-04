
using StockTrackingApp.Dtos.Products;

namespace StockTrackingApp.Business.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
        
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product,ProductDetailsDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product,ProductListDto>();
            CreateMap<Product,ProductDto>();
        }
    }
}

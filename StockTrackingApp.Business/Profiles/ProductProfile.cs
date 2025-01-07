
using StockTrackingApp.Dtos.Products;

namespace StockTrackingApp.Business.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<Product,ProductCreateDto>();
            CreateMap<Product,ProductDetailsDto>();
            CreateMap<Product,ProductUpdateDto>();
            CreateMap<Product,ProductListDto>();
        }
    }
}


using StockTrackingApp.Dtos.Stocks;

namespace StockTrackingApp.Business.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockCreateDto, Stock>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<Stock,StockDto>();
            CreateMap<Stock,StockListDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));  // ProductName'i Product.Name'e maple
            CreateMap<Stock,StockDetailsDto>();

        }
    }
}

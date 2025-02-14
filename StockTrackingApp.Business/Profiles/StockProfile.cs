
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
            CreateMap<Stock,StockListDto>();
            CreateMap<Stock,StockDetailsDto>();

        }
    }
}

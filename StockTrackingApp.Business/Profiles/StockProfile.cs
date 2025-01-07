
using StockTrackingApp.Dtos.Stocks;

namespace StockTrackingApp.Business.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock,StockCreateDto>();
            CreateMap<Stock,StockDto>();
            CreateMap<Stock,StockListDto>();

        }
    }
}

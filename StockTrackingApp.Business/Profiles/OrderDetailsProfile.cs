
using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Business.Profiles
{
    public class OrderDetailsProfile :Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetailCreateDto, OrderDetail>();
            CreateMap<OrderDetail,OrderDetailDetailsDto>();
            CreateMap<OrderDetail,OrderDetailDto>()
                 .ForMember(dest => dest.StockName, opt => opt.MapFrom(o => o.Stock.Product.Name)); 
            CreateMap<OrderDetail,OrderDetailListDto>();
            CreateMap<OrderDetailUpdateDto, OrderDetail>();
        }
    }
}

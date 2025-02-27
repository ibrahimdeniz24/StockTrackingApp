
using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Business.Profiles
{
    public class OrderDetailsProfile :Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetailCreateDto, OrderDetail>();
            CreateMap<OrderDetail,OrderDetailDetailsDto>();
            CreateMap<OrderDetail,OrderDetailDto>();
            CreateMap<OrderDetail,OrderDetailListDto>();
            CreateMap<OrderDetail,OrderDetailUpdateDto>();
        }
    }
}

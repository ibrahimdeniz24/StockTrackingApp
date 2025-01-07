using StockTrackingApp.Dtos.Orders;
using System;

namespace StockTrackingApp.Business.Profiles
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderCreateDto>();
            CreateMap<Order,OrderDto>();
            CreateMap<Order,OrderListDto>();
        }
    }
}

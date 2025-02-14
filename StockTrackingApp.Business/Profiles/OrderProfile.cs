using StockTrackingApp.Dtos.Orders;
using System;

namespace StockTrackingApp.Business.Profiles
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order,OrderDto>();
            CreateMap<Order,OrderListDto>();
            CreateMap<Order, OrderDetailsDto>();
        }
    }
}

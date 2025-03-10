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
            CreateMap<Order,OrderListDto>()
                .ForMember(dest=>dest.CustomerName, opt=>opt.MapFrom(o=>o.Customer.CompanyName));
            CreateMap<Order, OrderDetailsDto>();
        }
    }
}

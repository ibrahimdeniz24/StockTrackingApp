﻿
using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Dtos.Orders
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string? CustomerName { get; set; }

        public string Description { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderDetailListDto> OrderDetailListDtos { get; set; }
    }
}

﻿
using StockTrackingApp.Core.Enums;
using StockTrackingApp.Core.Utilities.Helpers;
using StockTrackingApp.Dtos.Orders;
using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> GetByIdAsync(Guid id);
        Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto orderCreateDto);

        Task<IDataResult<List<OrderListDto>>> GetAllAsync();
        Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<OrderDetailsDto>> GetDetailsByIdAsync(Guid id);
        Task<PagedResult<OrderListDto>> GetPagedOrdersAsync(int pageNumber, int pageSize, string searchTerm);

        Task<IResult> ChangeStatusAsync(Guid orderId, OrderStatus newStatus);


    }
}

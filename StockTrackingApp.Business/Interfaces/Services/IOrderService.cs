using StockTrackingApp.Dtos.Orders;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> GetByIdAsync(Guid id);
        Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto orderCreateDto);

        Task<IDataResult<List<OrderDetailsDto>>> GetAllAsync();
        //Task<IDataResult<OrderDto>> UpdateAsync(o customerUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<OrderDetailsDto>> GetDetailsByIdAsync(Guid id);
    }
}

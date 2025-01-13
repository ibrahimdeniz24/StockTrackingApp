
using StockTrackingApp.Dtos.Stocks;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IStockService
    {
        Task<IDataResult<StockDto>> GetByIdAsync(Guid id);
        Task<IDataResult<StockDto>> AddAsync(StockCreateDto stockCreateDto);

        Task<IDataResult<List<StockListDto>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
    }
}

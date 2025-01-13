using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IStockTransactionService
    {
        Task<IDataResult<StockTransactionDto>> GetByIdAsync(Guid id);
        Task<IDataResult<StockTransactionDto>> AddAsync(StockTransactionCreateDto stockTransactionCreateDto);

        Task<IDataResult<List<StockTransactionListDto>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
    }
}

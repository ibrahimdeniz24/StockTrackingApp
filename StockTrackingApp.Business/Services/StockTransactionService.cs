using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Business.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _stockTransactionRepository;
        private readonly IMapper _mapper;

        public StockTransactionService(IStockTransactionRepository stockTransactionRepository, IMapper mapper)
        {
            _stockTransactionRepository = stockTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<StockTransactionDto>> AddAsync(StockTransactionCreateDto stockTransactionCreateDto)
        {
            var stockTransaction = _mapper.Map<StockTransaction>(stockTransactionCreateDto);

            await _stockTransactionRepository.AddAsync(stockTransaction);
            await _stockTransactionRepository.SaveChangesAsync();

            return new SuccessDataResult<StockTransactionDto>(_mapper.Map<StockTransactionDto>(stockTransaction), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var stockTransaction = await _stockTransactionRepository.GetByIdAsync(id);
                if (stockTransaction is null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }

                await _stockTransactionRepository.DeleteAsync(stockTransaction);
                await _stockTransactionRepository.SaveChangesAsync();

                return new SuccessResult(Messages.DeleteSuccess);


            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<StockTransactionListDto>>> GetAllAsync()
        {
            var stcokTransactions = await _stockTransactionRepository.GetAllAsync();
            if (stcokTransactions is null)
            {
                return new ErrorDataResult<List<StockTransactionListDto>>(Messages.ListNotFound);
            }

            return new SuccessDataResult<List<StockTransactionListDto>>(stcokTransactions.Adapt<List<StockTransactionListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<StockTransactionDto>> GetByIdAsync(Guid id)
        {
            var stockTrasaction = await _stockTransactionRepository.GetByIdAsync(id);

            if (stockTrasaction != null)
            {
                return new SuccessDataResult<StockTransactionDto>(_mapper.Map<StockTransactionDto>(stockTrasaction), Messages.FoundSuccess);
            }

            return new ErrorDataResult<StockTransactionDto>(Messages.FoundFail);
        }
    }
}

using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Stocks;

namespace StockTrackingApp.Business.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<StockDto>> AddAsync(StockCreateDto stockCreateDto)
        {
            var stock = _mapper.Map<Stock>(stockCreateDto);

            await _stockRepository.AddAsync(stock);
            await _stockRepository.SaveChangesAsync();

            return new SuccessDataResult<StockDto>(_mapper.Map<StockDto>(stock), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var stock = await _stockRepository.GetByIdAsync(id);
                if (stock == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _stockRepository.DeleteAsync(stock);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<StockListDto>>> GetAllAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();

            return new SuccessDataResult<List<StockListDto>>(stocks.Adapt<List<StockListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<StockDto>> GetByIdAsync(Guid id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if(stock != null)
            {
                return new SuccessDataResult<StockDto>(_mapper.Map<StockDto>(stock),Messages.FoundSuccess);
            }

            return new ErrorDataResult<StockDto>(Messages.FoundFail);

        }
    }
}

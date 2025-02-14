using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Stocks;
using StockTrackingApp.Entities.DbSets;

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
                await _stockRepository.SaveChangesAsync();
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

        public async Task<IDataResult<StockDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var stockDetailsDto = await _stockRepository.GetByIdAsync(id);
            if (stockDetailsDto != null)
            {
                return new SuccessDataResult<StockDetailsDto>(_mapper.Map<StockDetailsDto>(stockDetailsDto), Messages.FoundSuccess);
            }

            return new ErrorDataResult<StockDetailsDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<StockDto>> UpdateAsync(StockUpdateDto stockUpdateDto)
        {
            var stockDto =  await _stockRepository.GetByIdAsync(stockUpdateDto.Id);
            if (stockDto == null)
            {
                return new ErrorDataResult<StockDto>(Messages.FoundFail);
            }

            var updatedStock = _mapper.Map(stockUpdateDto, stockDto);
            await _stockRepository.UpdateAsync(updatedStock);
            await _stockRepository.SaveChangesAsync();
            return new SuccessDataResult<StockDto>(_mapper.Map<StockDto>(updatedStock), Messages.UpdateSuccess);
        }
    }
}

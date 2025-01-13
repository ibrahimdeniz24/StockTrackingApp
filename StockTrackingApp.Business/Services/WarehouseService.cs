
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Warehouses;

namespace StockTrackingApp.Business.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<WarehouseDto>> AddAsync(WarehouseCreateDto warehouseCreateDto)
        {
            var hasWarehouse = await _warehouseRepository.AnyAsync(x => x.Name.ToLower().Trim() == warehouseCreateDto.Name.ToLower().Trim());
            if (hasWarehouse)
            {
                return new ErrorDataResult<WarehouseDto>(Messages.AddFailAlreadyExists);
            }

            var warehouse = _mapper.Map<Warehouse>(warehouseCreateDto);
            await _warehouseRepository.AddAsync(warehouse);
            await _warehouseRepository.SaveChangesAsync();

            return new SuccessDataResult<WarehouseDto>(_mapper.Map<WarehouseDto>(warehouse), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetByIdAsync(id);
                if (warehouse == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _warehouseRepository.DeleteAsync(warehouse);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<WarehouseListDto>>> GetAllAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();

            return new SuccessDataResult<List<WarehouseListDto>>(warehouses.Adapt<List<WarehouseListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<WarehouseDto>> GetByIdAsync(Guid id)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id);
            if (warehouse != null)
            {
                return new SuccessDataResult<WarehouseDto>(_mapper.Map<WarehouseDto>(warehouse), Messages.FoundSuccess);
            }

            return new ErrorDataResult<WarehouseDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<WarehouseDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id);
            if (warehouse == null)
            {
                return new ErrorDataResult<WarehouseDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<WarehouseDetailsDto>(_mapper.Map<WarehouseDetailsDto>(warehouse), Messages.ListedSuccess);
        }
    }
}

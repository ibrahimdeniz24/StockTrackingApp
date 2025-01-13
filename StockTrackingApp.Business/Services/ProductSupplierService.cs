
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.ProductSuppliers;

namespace StockTrackingApp.Business.Services
{
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IProductSupplierRepository _repository;
        private readonly IMapper _mapper;

        public ProductSupplierService(IProductSupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ProductSupplierDto>> AddAsync(ProductSupplierCreateDto productSupplierCreateDto)
        {

            var productSupplier = _mapper.Map<ProductSupplier>(productSupplierCreateDto);
            await _repository.AddAsync(productSupplier);
            await _repository.SaveChangesAsync();

            return new SuccessDataResult<ProductSupplierDto>(_mapper.Map<ProductSupplierDto>(productSupplier), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _repository.DeleteAsync(product);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<ProductSupplierDto>>> GetAllAsync()
        {
            var productSuppliers = await _repository.GetAllAsync();

            return new SuccessDataResult<List<ProductSupplierDto>>(productSuppliers.Adapt<List<ProductSupplierDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<ProductSupplierDto>> GetByIdAsync(Guid id)
        {
            var productSupplier = await _repository.GetByIdAsync(id);
            if (productSupplier != null)
            {
                return new SuccessDataResult<ProductSupplierDto>(_mapper.Map<ProductSupplierDto>(productSupplier), Messages.FoundSuccess);
            }

            return new ErrorDataResult<ProductSupplierDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<ProductSupplierDetailDto>> GetDetailsByIdAsync(Guid id)
        {
            var productSupplier = await _repository.GetByIdAsync(id);
            if (productSupplier == null)
            {
                return new ErrorDataResult<ProductSupplierDetailDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<ProductSupplierDetailDto>(_mapper.Map<ProductSupplierDetailDto>(productSupplier), Messages.ListedSuccess);
        }

        public async Task<IDataResult<ProductSupplierDto>> UpdateAsync(ProductSupplierUpdateDto productSupplierUpdateDto)
        {
            var productSupplier = await _repository.GetByIdAsync(productSupplierUpdateDto.Id);
            if (productSupplier == null)
            {
                return new ErrorDataResult<ProductSupplierDto>(Messages.FoundFail);
            }

            var updatedProductSupplier = _mapper.Map(productSupplierUpdateDto, productSupplier);

            await _repository.UpdateAsync(updatedProductSupplier);
            await _repository.SaveChangesAsync();

            return new SuccessDataResult<ProductSupplierDto>(_mapper.Map<ProductSupplierDto>(updatedProductSupplier), Messages.UpdateSuccess);
        }
    }
}

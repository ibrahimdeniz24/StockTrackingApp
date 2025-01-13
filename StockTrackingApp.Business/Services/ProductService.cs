
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Products;

namespace StockTrackingApp.Business.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ProductDto>> AddAsync(ProductCreateDto productCreateDto)
        {
            var hasProduct = await _productRepository.AnyAsync(x => x.SKU.ToLower().Trim() == productCreateDto.SKU.ToLower().Trim());
            if (hasProduct)
            {
                return new ErrorDataResult<ProductDto>(Messages.AddFailAlreadyExists);
            }

            var product = _mapper.Map<Product>(productCreateDto);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(product), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _productRepository.DeleteAsync(product);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public async Task<IDataResult<List<ProductListDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return new SuccessDataResult<List<ProductListDto>>(products.Adapt<List<ProductListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<ProductDto>> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(product), Messages.FoundSuccess);
            }

            return new ErrorDataResult<ProductDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<ProductDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new ErrorDataResult<ProductDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<ProductDetailsDto>(_mapper.Map<ProductDetailsDto>(product), Messages.ListedSuccess);
        }

        public async Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await _productRepository.GetByIdAsync(productUpdateDto.Id);
            if (product == null)
            {
                return new ErrorDataResult<ProductDto>(Messages.FoundFail);
            }

            var updatedProduct = _mapper.Map(productUpdateDto, product);

            await _productRepository.UpdateAsync(updatedProduct);
            await _productRepository.SaveChangesAsync();

            return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(updatedProduct), Messages.UpdateSuccess);
        }
    }
}

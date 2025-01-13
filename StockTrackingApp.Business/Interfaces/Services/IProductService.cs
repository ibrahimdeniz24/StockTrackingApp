using StockTrackingApp.Dtos.Products;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetByIdAsync(Guid id);

        Task<IDataResult<List<ProductListDto>>> GetAllAsync();

        Task<IDataResult<ProductDetailsDto>> GetDetailsByIdAsync(Guid id);
        Task<IDataResult<ProductDto>> AddAsync(ProductCreateDto productCreateDto);

        Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto);

        Task<IResult> DeleteAsync(Guid id);
    }
}

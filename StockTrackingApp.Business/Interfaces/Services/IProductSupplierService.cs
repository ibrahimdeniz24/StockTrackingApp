
using StockTrackingApp.Dtos.ProductSuppliers;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IProductSupplierService
    {
        Task<IDataResult<ProductSupplierDto>> GetByIdAsync(Guid id);
        Task<IDataResult<ProductSupplierDto>> AddAsync(ProductSupplierCreateDto productSupplierCreateDto);


        Task<IDataResult<List<ProductSupplierDto>>> GetAllAsync();
        Task<IDataResult<ProductSupplierDto>> UpdateAsync(ProductSupplierUpdateDto productSupplierUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<ProductSupplierDetailDto>> GetDetailsByIdAsync(Guid id);
    }
}

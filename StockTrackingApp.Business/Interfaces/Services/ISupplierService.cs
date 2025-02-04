
using StockTrackingApp.Dtos.Suppliers;
using System.Web.Mvc;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<IDataResult<SupplierDto>> GetByIdAsync(Guid id);
        Task<IDataResult<SupplierDto>> AddAsync(SupplierCreateDto supplierCreateDto);

        Task<IDataResult<List<SupplierListDto>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<SupplierDetailsDto>> GetDetailsByIdAsync(Guid id);

        Task<IDataResult<SupplierDto>> UpdateAsync(SupplierUpdateDto supplierUpdateDto);

        Task<List<SelectListItem>> GetAllSupplierAsSelectListAsync();
    }
}

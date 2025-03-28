
using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IPurchaseOrderDetailService
    {
        Task<IDataResult<PurchaseOrderDetailDto>> GetByIdAsync(Guid id);
        Task<IDataResult<PurchaseOrderDetailDto>> AddAsync(PurchaseOrderDetailCreateDto purchaseOrderDetailCreateDto);

        Task<IDataResult<List<PurchaseOrderDetailListDto>>> GetAllAsync();
        Task<IDataResult<PurchaseOrderDetailDto>> UpdateAsync(PurchaseOrderDetailUpdateDto purchaseOrderDetailUpdateDto);
        Task<IResult> DeleteAsync(Guid id);

    }
}

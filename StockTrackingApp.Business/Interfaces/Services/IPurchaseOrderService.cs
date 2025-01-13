
using StockTrackingApp.Dtos.PurchaseOrders;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IPurchaseOrderService
    {
        Task<IDataResult<PurchaseOrderDto>> GetByIdAsync(Guid id);
        Task<IDataResult<PurchaseOrderDto>> AddAsync(PurchaseOrderCreateDto purchaseOrderCreateDto);

        Task<IDataResult<List<PurchaseOrderListDto>>> GetAllAsync();
        Task<IDataResult<PurchaseOrderDto>> UpdateAsync(PurchaseOrderUpdateDto purchaseOrderUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<PurchaseOrderDetailsDto>> GetDetailsByIdAsync(Guid id);
    }
}

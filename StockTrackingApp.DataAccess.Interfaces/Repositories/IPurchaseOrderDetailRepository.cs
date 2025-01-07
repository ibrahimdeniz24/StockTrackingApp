
namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IPurchaseOrderDetailRepository : IAsyncRepository, IAsyncFindableRepository<PurchaseOrderDetail>, IAsyncInsertableRepository<PurchaseOrderDetail>, IAsyncDeleteableRepository<PurchaseOrderDetail>, IAsyncQueryableRepository<PurchaseOrderDetail>, IAsyncUpdateableRepository<PurchaseOrderDetail>
    {
    }
}

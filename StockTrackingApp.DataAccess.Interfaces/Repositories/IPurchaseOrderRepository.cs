

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IPurchaseOrderRepository : IAsyncRepository, IAsyncFindableRepository<PurchaseOrder>, IAsyncInsertableRepository<PurchaseOrder>, IAsyncDeleteableRepository<PurchaseOrder>, IAsyncQueryableRepository<PurchaseOrder>, IAsyncUpdateableRepository<PurchaseOrder>
    {
    }
}

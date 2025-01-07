namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IOrderRepository : IAsyncRepository, IAsyncFindableRepository<Order>, IAsyncInsertableRepository<Order>, IAsyncDeleteableRepository<Order>, IAsyncQueryableRepository<Order>, IAsyncUpdateableRepository<Order>
    {
    }
}

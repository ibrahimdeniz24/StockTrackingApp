

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IStockRepository : IAsyncRepository, IAsyncFindableRepository<Stock>, IAsyncInsertableRepository<Stock>, IAsyncDeleteableRepository<Stock>, IAsyncQueryableRepository<Stock>, IAsyncUpdateableRepository<Stock>
    {
        Task<Stock> GetBySkuSupplierAndPriceAsync(string skuNumber, Guid supplierId, decimal price);

    }
}

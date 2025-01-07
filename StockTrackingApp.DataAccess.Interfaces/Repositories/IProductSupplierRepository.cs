namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IProductSupplierRepository : IAsyncRepository, IAsyncFindableRepository<ProductSupplier>, IAsyncInsertableRepository<ProductSupplier>, IAsyncDeleteableRepository<ProductSupplier>, IAsyncQueryableRepository<ProductSupplier>, IAsyncUpdateableRepository<ProductSupplier>
    {
    }
}

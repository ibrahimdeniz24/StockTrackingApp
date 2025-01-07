namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface ICategoryRepository : IAsyncRepository, IAsyncInsertableRepository<Category>, IAsyncQueryableRepository<Category>, IAsyncFindableRepository<Category>,
  IAsyncUpdateableRepository<Category>, IAsyncDeleteableRepository<Category>
    {
    }
}

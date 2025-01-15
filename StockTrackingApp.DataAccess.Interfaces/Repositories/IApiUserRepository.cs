

using StockTrackingApp.Entities.ApiEntities;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IApiUserRepository : IAsyncRepository, IAsyncInsertableRepository<ApiUser>, IAsyncQueryableRepository<ApiUser>, IAsyncFindableRepository<ApiUser>, IAsyncDeleteableRepository<ApiUser>, IAsyncUpdateableRepository<ApiUser>, IAsyncTransactionRepository
    {
        Task<ApiUser?> GetByIdentityIdAsync(string identityId);
    }
}

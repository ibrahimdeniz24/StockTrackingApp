

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IRegisterCodeRepository : IAsyncRepository, IAsyncInsertableRepository<RegisterCode>, IAsyncQueryableRepository<RegisterCode>, IAsyncDeleteableRepository<RegisterCode>, IAsyncFindableRepository<RegisterCode>, IAsyncUpdateableRepository<RegisterCode>, IAsyncOrderableRepository<RegisterCode>
    {
    }
}

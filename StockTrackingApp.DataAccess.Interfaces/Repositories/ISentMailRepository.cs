

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface ISentMailRepository : IRepository, IAsyncQueryableRepository<SentMail>, IAsyncFindableRepository<SentMail>, IAsyncUpdateableRepository<SentMail>, IAsyncInsertableRepository<SentMail>, IAsyncDeleteableRepository<SentMail>
    {
    }
}

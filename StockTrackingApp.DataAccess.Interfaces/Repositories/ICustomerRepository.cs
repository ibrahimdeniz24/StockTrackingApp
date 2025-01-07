
namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{ 
    public interface ICustomerRepository : IAsyncRepository, IAsyncInsertableRepository<Customer>,  IAsyncFindableRepository<Customer>,IAsyncUpdateableRepository<Customer>, IAsyncDeleteableRepository<Customer>, IAsyncTransactionRepository
    {
    }
}

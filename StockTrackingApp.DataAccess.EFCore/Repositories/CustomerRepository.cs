
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class CustomerRepository : EFBaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

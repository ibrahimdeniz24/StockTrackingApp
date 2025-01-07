
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class OrderRepository : EFBaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}


namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class OrderDetailRepository : EFBaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

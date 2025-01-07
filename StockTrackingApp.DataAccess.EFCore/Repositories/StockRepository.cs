
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class StockRepository : EFBaseRepository<Stock>, IStockRepository
    {
        public StockRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

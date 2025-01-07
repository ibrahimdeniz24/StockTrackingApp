
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class StockTransactionRepository : EFBaseRepository<StockTransaction>, IStockTransactionRepository
    {
        public StockTransactionRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

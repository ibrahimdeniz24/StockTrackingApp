
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class PurchaseOrderRepository : EFBaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

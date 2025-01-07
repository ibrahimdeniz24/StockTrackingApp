
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class PurchaseOrderDetailRepository : EFBaseRepository<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

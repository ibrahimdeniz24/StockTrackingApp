
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class SupplierRepository : EFBaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

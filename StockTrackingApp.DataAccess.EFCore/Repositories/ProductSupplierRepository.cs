
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class ProductSupplierRepository : EFBaseRepository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

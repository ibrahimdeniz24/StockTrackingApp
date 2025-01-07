
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class ProductRepository : EFBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

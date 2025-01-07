
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class CategoryRepository : EFBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

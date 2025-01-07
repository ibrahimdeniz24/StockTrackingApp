
namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class WarehouseRepository : EFBaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}

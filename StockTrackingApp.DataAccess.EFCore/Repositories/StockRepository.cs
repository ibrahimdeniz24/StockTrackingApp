

using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class StockRepository : EFBaseRepository<Stock>, IStockRepository
    {
        public StockRepository(StockAppDbContext context) : base(context)
        {
        }

        public async Task<Stock> GetBySkuSupplierAndPriceAsync(string skuNumber, Guid supplierId, decimal price)
        {
            return await _table
                 .Include(x => x.Supplier)
                 .Include(x => x.Product)
                 .FirstOrDefaultAsync(x => x.Product.SKU == skuNumber
                                        && x.SupplierId == supplierId
                                        && x.PurchasePrice == price);
        }
    }
}

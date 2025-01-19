using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using StockTrackingApp.DataAccess.Contexts;


namespace StockTrackingApp.DataAccess.Factories
{
    public class StockAppDbContextFactory : IDesignTimeDbContextFactory<StockAppDbContext>
    {
        public StockAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockAppDbContext>();
            optionsBuilder.UseSqlServer(StockAppDbContext.ConnectionName);

            return new StockAppDbContext(optionsBuilder.Options);
        }
    }
}


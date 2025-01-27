using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using StockTrackingApp.DataAccess.Contexts;
using Microsoft.Extensions.Configuration;


namespace StockTrackingApp.DataAccess.Factories
{
    public class StockAppDbContextFactory : IDesignTimeDbContextFactory<StockAppDbContext>
    {
        public StockAppDbContext CreateDbContext(string[] args)
        {
            // Uygulama dizininizi alıyorsunuz
            var optionsBuilder = new DbContextOptionsBuilder<StockAppDbContext>();

            // Bağlantı dizesini doğrudan burada belirtebilirsiniz
            var connectionString = "Data Source=DENIZ\\SQL;Initial Catalog=StockTrackingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // Bağlantı dizesini DbContext'e bağlıyoruz
            optionsBuilder.UseSqlServer(connectionString);

            // DbContext'i döndürüyoruz
            return new StockAppDbContext(optionsBuilder.Options);
        }
    }
}


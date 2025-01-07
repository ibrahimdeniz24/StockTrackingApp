
namespace StockTrackingApp.Entities.Configuration
{
    public class StockConfiguration :AuditableEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasMany(x => x.StockTransactions).WithOne(x => x.Stock).HasForeignKey(x => x.StockId);
            base.Configure(builder);
        }
    }
}

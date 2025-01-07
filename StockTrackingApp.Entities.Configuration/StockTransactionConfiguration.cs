
namespace StockTrackingApp.Entities.Configuration
{
    public class StockTransactionConfiguration :AuditableEntityConfiguration<StockTransaction>
    {
        public override void Configure(EntityTypeBuilder<StockTransaction> builder)
        {
            base.Configure(builder);
        }
    }
}

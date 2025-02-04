
namespace StockTrackingApp.Entities.Configuration
{
    public class StockTransactionConfiguration :AuditableEntityConfiguration<StockTransaction>
    {
        public override void Configure(EntityTypeBuilder<StockTransaction> builder)
        {
            builder.HasOne(st => st.Stock).WithMany().HasForeignKey(st => st.StockId);
            builder.Property(st => st.TransactionDate).IsRequired();
            base.Configure(builder);
        }
    }
}

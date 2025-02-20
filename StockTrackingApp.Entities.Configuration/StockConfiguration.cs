
namespace StockTrackingApp.Entities.Configuration
{
    public class StockConfiguration :AuditableEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasOne(s => s.Product).WithMany(p => p.Stocks).HasForeignKey(s => s.ProductId);
            builder.HasOne(s => s.Warehouse).WithMany(w => w.Stocks).HasForeignKey(s => s.WareHouseId);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(o => o.PurchasePrice).HasPrecision(18, 4);
            base.Configure(builder);
        }
    }
}

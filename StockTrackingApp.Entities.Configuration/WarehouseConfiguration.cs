
namespace StockTrackingApp.Entities.Configuration
{
    public class WarehouseConfiguration:AuditableEntityConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.Property(w => w.Name).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}

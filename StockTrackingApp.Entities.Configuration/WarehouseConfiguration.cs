
namespace StockTrackingApp.Entities.Configuration
{
    public class WarehouseConfiguration:AuditableEntityConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasMany(x => x.Stocks).WithOne(x => x.Warehouse).HasForeignKey(x => x.WareHouseId);
            base.Configure(builder);
        }
    }
}

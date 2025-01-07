
namespace StockTrackingApp.Entities.Configuration
{
    internal class SupplierConfiguration:AuditableEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasMany(x=>x.ProductSuppliers).WithOne(x=>x.Supplier).HasForeignKey(x=>x.SupplierId);
            builder.HasMany(x=>x.PurchaseOrders).WithOne(x=>x.Supplier).HasForeignKey(x=>x.SupplierId);
            base.Configure(builder);
        }
    }
}

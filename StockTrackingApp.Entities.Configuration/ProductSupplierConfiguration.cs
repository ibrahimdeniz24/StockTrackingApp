namespace StockTrackingApp.Entities.Configuration
{
    public class ProductSupplierConfiguration :AuditableEntityConfiguration<ProductSupplier>
    {
        public override void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            base.Configure(builder);
        }
    }
}

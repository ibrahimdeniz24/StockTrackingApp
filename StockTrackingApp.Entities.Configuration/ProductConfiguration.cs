namespace StockTrackingApp.Entities.Configuration
{
    public class ProductConfiguration :AuditableEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasMany(x=>x.Stocks).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x=>x.PurchaseOrderDetails).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x=>x.ProductSuppliers).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            base.Configure(builder);
        }
    }
}

namespace StockTrackingApp.Entities.Configuration
{
    public class ProductConfiguration :AuditableEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProductImage).IsRequired(false);
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasOne(x=>x.Supplier).WithMany(x=>x.Products).HasForeignKey(x=>x.SupplierId);
            base.Configure(builder);
        }
    }
}

namespace StockTrackingApp.Entities.Configuration
{
    public class CategoryConfiguration :AuditableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}

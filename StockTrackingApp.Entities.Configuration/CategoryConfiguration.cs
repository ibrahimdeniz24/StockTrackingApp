namespace StockTrackingApp.Entities.Configuration
{
    public class CategoryConfiguration :AuditableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(s=>s.Products).WithOne(s=>s.Category).HasForeignKey(s=>s.CategoryId);
            base.Configure(builder);
        }
    }
}

namespace StockTrackingApp.Entities.Configuration
{
    public class CustomerConfiguration :AuditableEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}

namespace StockTrackingApp.Entities.Configuration
{
    public class CustomerConfiguration :AuditableEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(c => c.Orders).WithOne(s=>s.Customer).HasForeignKey(o => o.CustomerId);
            base.Configure(builder);
        }
    }
}

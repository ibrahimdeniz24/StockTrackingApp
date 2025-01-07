namespace StockTrackingApp.Entities.Configuration
{
    public class OrderConfiguration :AuditableEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {

            base.Configure(builder);
        }
    }
}

namespace StockTrackingApp.Entities.Configuration
{
    public class OrderDetailConfiguration :AuditableEntityConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
        }
    }
}

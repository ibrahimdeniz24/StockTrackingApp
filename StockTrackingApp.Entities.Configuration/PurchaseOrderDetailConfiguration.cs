
namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderDetailConfiguration : AuditableEntityConfiguration<PurchaseOrderDetail>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            base.Configure(builder);
        }
    }
}

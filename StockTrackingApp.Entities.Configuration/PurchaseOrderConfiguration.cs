namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderConfiguration :AuditableEntityConfiguration<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasMany(x => x.PurchaseOrderDetails).WithOne(x => x.PurchaseOrder).HasForeignKey(x => x.PurchaseOrderId);
            base.Configure(builder);
        }
    }

}

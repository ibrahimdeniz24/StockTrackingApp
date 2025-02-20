namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderConfiguration :AuditableEntityConfiguration<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {

            builder.HasOne(po => po.Supplier).WithMany(s => s.PurchaseOrders).HasForeignKey(po => po.SupplierId);
            builder.Property(o => o.TotalAmount).HasPrecision(18, 4);
            base.Configure(builder);
        }
    }

}

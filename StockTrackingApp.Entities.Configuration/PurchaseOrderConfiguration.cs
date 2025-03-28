using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderConfiguration :AuditableEntityConfiguration<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {

            builder.HasOne(po => po.Supplier).WithMany(s => s.PurchaseOrders).HasForeignKey(po => po.SupplierId);
           
            builder.HasMany(od=>od.PurchaseOrderDetails)
                .WithOne(po => po.PurchaseOrder)
                .HasForeignKey(po => po.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.DeliveryDate).IsRequired();
            builder.HasIndex(o => o.OrderNo).IsUnique();
            builder.Property(o => o.TotalAmount).HasPrecision(18, 2);
            builder.Property(o => o.TotalExcludingVATAmount).HasPrecision(18, 2);
            builder.Property(o => o.TotalVATAmount).HasPrecision(18, 2);
            base.Configure(builder);
        }
    }

}

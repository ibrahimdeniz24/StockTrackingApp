
using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderDetailConfiguration : AuditableEntityConfiguration<PurchaseOrderDetail>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            // ✅ 1:N ilişki - Her PurchaseOrder birden fazla PurchaseOrderDetail'e sahip olabilir.
            builder.HasOne(pod => pod.PurchaseOrder)       // PurchaseOrderDetail, bir PurchaseOrder'a bağlıdır.
                   .WithMany(po => po.PurchaseOrderDetails) // PurchaseOrder, birden fazla PurchaseOrderDetail'e sahip olabilir.
                   .HasForeignKey(pod => pod.PurchaseOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pod => pod.Quantity)
                   .IsRequired();

            builder.Property(o => o.UnitPrice).HasPrecision(18, 2);
            builder.Property(o => o.TotalPriceExcludingVAT).HasPrecision(18, 2);
            builder.Property(o => o.TotalPriceIncludingVAT).HasPrecision(18, 2);
            builder.Property(o => o.VATAmount).HasPrecision(18, 2);

            base.Configure(builder);
        }
    }
}


using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class PurchaseOrderDetailConfiguration : AuditableEntityConfiguration<PurchaseOrderDetail>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            // ✅ 1:1 ilişki - Her PurchaseOrder'ın yalnızca bir PurchaseOrderDetail'i olabilir.
            builder.HasOne(pod => pod.PurchaseOrder)
                   .WithOne(po => po.PurchaseOrderDetail)  // 1:1 ilişki
                   .HasForeignKey<PurchaseOrderDetail>(pod => pod.PurchaseOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ✅ 1:N olarak bırakıldı (Bir Product, birden fazla PurchaseOrderDetail'de olabilir.)
            builder.HasOne(pod => pod.Product)
                   .WithMany()
                   .HasForeignKey(pod => pod.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pod => pod.Quantity)
                   .IsRequired();

            base.Configure(builder);
        }
    }
}


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


            // ✅ 1:N olarak bırakıldı (Bir Product, birden fazla PurchaseOrderDetail'de olabilir.)
            builder.HasOne(pod => pod.Product)
                   .WithMany()
                   .HasForeignKey(pod => pod.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pod => pod.Quantity)
                   .IsRequired();

            builder.Property(o => o.UnitPrice).HasPrecision(18, 4);

            base.Configure(builder);
        }
    }
}

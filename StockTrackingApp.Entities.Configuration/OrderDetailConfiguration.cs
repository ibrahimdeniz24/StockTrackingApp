using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class OrderDetailConfiguration :AuditableEntityConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // ✅ 1:1 ilişki - Her PurchaseOrder'ın yalnızca bir PurchaseOrderDetail'i olabilir.
            builder.HasOne(pod => pod.Order)
                   .WithOne(po => po.OrderDetail)  // 1:1 ilişki
                   .HasForeignKey<OrderDetail>(pod => pod.OrderId)
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

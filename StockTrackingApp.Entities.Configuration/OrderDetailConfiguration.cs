using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class OrderDetailConfiguration :AuditableEntityConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // ✅ 1:N ilişki - Her Order birden fazla OrderDetail'e sahip olabilir.
            builder.HasOne(pod => pod.Order)                 // OrderDetail bir Order'a ait
                   .WithMany(po => po.OrderDetails)          // Order birden fazla OrderDetail içerir
                   .HasForeignKey(pod => pod.OrderId)        // Foreign Key tanımı
                   .OnDelete(DeleteBehavior.Cascade);        // Sipariş silinince detaylar da silinir


            builder.Property(pod => pod.Quantity)
                   .IsRequired();
            builder.Property(o => o.UnitPrice).HasPrecision(18, 4);

            base.Configure(builder);
        }
    }
}

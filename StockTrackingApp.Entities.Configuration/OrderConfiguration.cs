using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class OrderConfiguration : AuditableEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.HasMany(o => o.OrderDetails)            // Order birden fazla OrderDetail'e sahiptir.
                   .WithOne(od => od.Order)                 // OrderDetail bir Order'a bağlıdır.
                   .HasForeignKey(od => od.OrderId)         // Foreign Key tanımı
                   .OnDelete(DeleteBehavior.Cascade);       // Silme davranışı (Cascade: İlişkili kayıtlar silinir)

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

using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class OrderConfiguration :AuditableEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.HasOne(o => o.OrderDetail) // Bire bir ilişkiyi burada tanımlıyoruz
             .WithOne(od => od.Order)
             .HasForeignKey<OrderDetail>(od => od.OrderId)
             .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;

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

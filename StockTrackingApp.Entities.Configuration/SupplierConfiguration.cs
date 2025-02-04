
using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class SupplierConfiguration:AuditableEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.CompanyName).IsRequired().HasMaxLength(100); ;
            base.Configure(builder);
        }
    }
}

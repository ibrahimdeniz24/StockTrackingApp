
using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.Entities.Configuration
{
    public class StockConfiguration :AuditableEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasOne(s => s.Product).WithMany(p => p.Stocks).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.Warehouse).WithMany(w => w.Stocks).HasForeignKey(s => s.WareHouseId);
            builder.HasOne(x => x.Supplier).WithMany(x => x.Stocks).HasForeignKey(x => x.SupplierId);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(o => o.PurchasePrice).HasPrecision(18, 4);

            base.Configure(builder);
        }
    }
}

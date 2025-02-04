
namespace StockTrackingApp.Entities.DbSets
{
    public class PurchaseOrderDetail :AuditableEntity
    {
        public int Quantity { get; set; } // Miktar
        public decimal UnitPrice { get; set; } // Birim Fiyat


        public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual Product Product { get; set; }


    }
}

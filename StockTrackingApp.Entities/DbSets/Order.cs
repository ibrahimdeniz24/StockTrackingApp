

namespace StockTrackingApp.Entities.DbSets
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Guid CustomerId { get; set; } // Müşteri ID (FK)
        public virtual Customer Customer { get; set; } // Müşteri İlişkisi
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Sipariş Tarihi
        public DateTime DeliveryDate { get; set; }

        public VatRate VatRate { get; set; }

        public string Description { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Sipariş Detayları

    }


}

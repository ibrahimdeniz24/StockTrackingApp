

namespace StockTrackingApp.Entities.DbSets
{
    public class Order : AuditableEntity
    {
        public Guid CustomerId { get; set; } // Müşteri ID (FK)
        public virtual Customer Customer { get; set; } // Müşteri İlişkisi
        public DateTime OrderDate { get; set; } // Sipariş Tarihi
        public DateTime DeliveryDate { get; set; }

        public decimal TotalAmount { get; set; } // Toplam Tutar

        public string Description { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual OrderDetail OrderDetail { get; set; } // Sipariş Detayları

    }


}

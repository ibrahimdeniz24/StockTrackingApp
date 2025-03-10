

namespace StockTrackingApp.Entities.DbSets
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string OrderNo { get; set; }
        public Guid CustomerId { get; set; } // Müşteri ID (FK)
        public virtual Customer Customer { get; set; } // Müşteri İlişkisi
        public DateTime OrderDate { get; set; }  // Sipariş Tarihi
        public DateTime DeliveryDate { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TotalExcludingVATAmount { get; set; }
        public decimal TotalVATAmount { get; set; }

        public string Description { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Sipariş Detayları

    }


}

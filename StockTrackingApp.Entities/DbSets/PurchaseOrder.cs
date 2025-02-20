using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Entities.DbSets
{
    public class PurchaseOrder :AuditableEntity
    {
        public DateTime OrderDate { get; set; }


        public DateTime DeliveryDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public virtual Supplier Supplier { get; set; }

        public Guid SupplierId { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    }
}

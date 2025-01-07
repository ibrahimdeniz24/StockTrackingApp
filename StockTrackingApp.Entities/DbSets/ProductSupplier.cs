using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Entities.DbSets
{
    public class ProductSupplier :AuditableEntity
    {
        public Guid ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public Guid SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Entities.DbSets
{
    public class Stock :AuditableEntity
    {
        public int Quantity { get; set; }

        public Warehouse Warehouse { get; set; }
        public Guid WareHouseId { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
    }
}

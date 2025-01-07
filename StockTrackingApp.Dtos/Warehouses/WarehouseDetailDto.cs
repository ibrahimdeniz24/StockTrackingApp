using StockTrackingApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Warehouses
{
    public class WarehouseDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Depo Adı
        public string Location { get; set; } // Lokasyon

        public string PhoneNumber { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}

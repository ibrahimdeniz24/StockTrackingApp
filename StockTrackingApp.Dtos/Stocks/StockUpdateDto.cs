using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockUpdateDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

    }
}

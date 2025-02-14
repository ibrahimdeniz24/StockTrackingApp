using StockTrackingApp.Dtos.StockTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockDetailsDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public IEnumerable<StockTransactionDto> StockTransactions { get; set; }
    }
}

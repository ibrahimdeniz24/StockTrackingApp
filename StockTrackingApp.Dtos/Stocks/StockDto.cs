using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockDto
    {
        public int Quantity { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public  IEnumerable<StockTransactionDto> StockTransactions { get; set; }
    }
}

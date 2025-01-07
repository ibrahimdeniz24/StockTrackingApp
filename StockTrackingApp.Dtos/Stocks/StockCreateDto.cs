using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockCreateDto
    {
        public int Quantity { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public virtual IEnumerable<StockTransactionCreateDto> StockTransactions { get; set; }
    }
}

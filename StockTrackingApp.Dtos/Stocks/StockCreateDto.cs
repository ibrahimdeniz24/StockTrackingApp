using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockCreateDto
    {
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; } 

        public virtual IEnumerable<StockTransactionCreateDto> StockTransactions { get; set; }
    }
}

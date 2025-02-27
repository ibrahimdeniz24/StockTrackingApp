using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockListDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public string WareHouseName { get; set; }

        public string SKU { get; set; }

        public string ProductName { get; set; }
        public byte[]? ProductImage { get; set; }
        public virtual IEnumerable<StockTransactionListDto> StockTransactions { get; set; }
    }
}

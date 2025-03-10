using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockDetailsDto
    {
        public Guid Id { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat
        public int Quantity { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public string WareHouseName { get; set; }

        public string SKU { get; set; }

        public string ProductName { get; set; }
        public byte[]? ProductImage { get; set; }

        public IEnumerable<StockTransactionDto> StockTransactions { get; set; }
    }
}

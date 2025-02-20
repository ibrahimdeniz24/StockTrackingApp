namespace StockTrackingApp.UI.Areas.Admin.Models.StockVMs
{
    public class AdminStockUpdateVM
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
    }
}

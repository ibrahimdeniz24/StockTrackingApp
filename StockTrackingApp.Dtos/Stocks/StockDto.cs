﻿using StockTrackingApp.Dtos.StockTransactions;

namespace StockTrackingApp.Dtos.Stocks
{
    public class StockDto
    {
        public  Guid Id { get; set; }
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public  IEnumerable<StockTransactionDto> StockTransactions { get; set; }
    }
}

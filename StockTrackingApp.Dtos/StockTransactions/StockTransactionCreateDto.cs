using StockTrackingApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.StockTransactions
{
    public class StockTransactionCreateDto
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; } // İşlem Miktarı
        public DateTime TransactionDate { get; set; } // İşlem Tarihi
        public TransactionType TransactionType { get; set; } // İşlem Tipi (Giriş/Çıkış)

        public Guid StockId { get; set; }
    }
}

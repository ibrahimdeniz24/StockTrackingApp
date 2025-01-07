

namespace StockTrackingApp.Entities.DbSets
{
    public class StockTransaction : AuditableEntity
    {

        public DateTime Date { get; set; }
        public int Quantity { get; set; } // İşlem Miktarı
        public DateTime TransactionDate { get; set; } // İşlem Tarihi
        public TransactionType TransactionType { get; set; } // İşlem Tipi (Giriş/Çıkış)

        public Guid StockId { get; set; }
        public virtual Stock Stock { get; set; }

    }
}

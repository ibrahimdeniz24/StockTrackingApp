

namespace StockTrackingApp.Entities.DbSets
{
    public class Warehouse : AuditableEntity
    {
        public Warehouse()
        {
            Stocks = new HashSet<Stock>();
        }
        public string Name { get; set; } // Depo Adı
        public string Location { get; set; } // Lokasyon

        public string PhoneNumber { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }

    }
}

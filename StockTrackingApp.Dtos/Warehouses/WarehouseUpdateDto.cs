using StockTrackingApp.Entities.DbSets;


namespace StockTrackingApp.Dtos.Warehouses
{
    public class WarehouseUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Depo Adı
        public string Location { get; set; } // Lokasyon

        public string PhoneNumber { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}

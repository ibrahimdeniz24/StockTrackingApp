

namespace StockTrackingApp.Entities.DbSets
{
    public class Supplier :AuditableEntity
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Products = new HashSet<Product>();
        }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}



namespace StockTrackingApp.Entities.DbSets
{
    public class Supplier :AuditableEntity
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ProductSuppliers = new HashSet<ProductSupplier>();
        }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }

    }
}

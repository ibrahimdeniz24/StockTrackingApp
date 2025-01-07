
namespace StockTrackingApp.Entities.DbSets
{
    public class Customer :AuditableEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
        public virtual ICollection<Order> Orders { get; set; } // Siparişler
    }
}



namespace StockTrackingApp.Entities.DbSets
{
    public class Category :AuditableEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

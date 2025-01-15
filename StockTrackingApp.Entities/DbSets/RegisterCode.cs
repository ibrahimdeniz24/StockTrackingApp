
namespace StockTrackingApp.Entities.DbSets
{
    public class RegisterCode :AuditableEntity
    {
        public string Code { get; set; }
        public DateTime CodeCreationTime { get; set; } = DateTime.Now;
        public DateTime CodeExpirationTime { get; set; } = DateTime.Now.AddMinutes(15);
        public string CreatedForId { get; set; }
    }
}


namespace StockTrackingApp.Dtos.Suppliers
{
    public class SupplierUpdateDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
    }
}

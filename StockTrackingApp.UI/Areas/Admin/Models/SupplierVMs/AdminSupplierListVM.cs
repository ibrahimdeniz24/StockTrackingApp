namespace StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs
{
    public class AdminSupplierListVM
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
    }
}

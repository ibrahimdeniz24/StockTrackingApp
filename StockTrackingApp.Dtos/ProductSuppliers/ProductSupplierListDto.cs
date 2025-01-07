

namespace StockTrackingApp.Dtos.ProductSuppliers
{
    public class ProductSupplierListDto
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; } // Tedarikçi ID
        public string SupplierName { get; set; } // Tedarikçi Adı

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
    }
}


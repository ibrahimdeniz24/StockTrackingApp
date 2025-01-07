
namespace StockTrackingApp.Dtos.ProductSuppliers
{
    public class ProductSupplierUpdateDto
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; } // Tedarikçi ID
        public string SupplierName { get; set; } // Tedarikçi Adı

        public Guid ProductId { get; set; } // Ürün ID

        public string ProductName { get; set; } //Ürün Adı
    }
}

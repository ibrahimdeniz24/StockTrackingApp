using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.StockVMs
{
    public class AdminStockUpdateVM
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // AlışFiyat

        [Required(ErrorMessage = "Depo seçimi zorunludur.")]
        public Guid WareHouseId { get; set; }
        
        [Required(ErrorMessage = "Ürün seçimi zorunludur.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        public Guid SupplierId { get; set; }
    }
}

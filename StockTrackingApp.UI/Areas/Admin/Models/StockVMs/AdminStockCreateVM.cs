using System.ComponentModel.DataAnnotations;

namespace StockTrackingApp.UI.Areas.Admin.Models.StockVMs
{
    public class AdminStockCreateVM
    {
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // AlışFiyat
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        public Guid SupplierId { get; set; }

    }
}

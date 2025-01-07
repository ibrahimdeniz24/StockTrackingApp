using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.ProductSuppliers
{
    public class ProductSupplierCreateDto
    {
        public Guid SupplierId { get; set; } // Tedarikçi ID
        public string SupplierName { get; set; } // Tedarikçi Adı

        public Guid ProductId { get; set; } // Ürün ID

        public string ProductName { get; set; } //Ürün Adı
    }
}

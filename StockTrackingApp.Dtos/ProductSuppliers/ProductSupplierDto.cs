using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.ProductSuppliers
{
    public class ProductSupplierDto
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; } // Tedarikçi ID
        public string SupplierName { get; set; } // Tedarikçi Adı

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
    }
}

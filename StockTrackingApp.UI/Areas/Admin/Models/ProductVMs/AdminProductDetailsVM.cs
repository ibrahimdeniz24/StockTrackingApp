﻿using StockTrackingApp.Entities.Enums;
using System.Web.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Models.ProductVMs
{
    public class AdminProductDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ürün Adı
        public string SKU { get; set; } // Stok Kodu
        public Guid CategoryId { get; set; } // Kategori ID
        public string CategoryName { get; set; } // Kategori ID
        public Guid SupplierId { get; set; } // Kategori ID
        public string SupplierName { get; set; } // Kategori ID

        public byte[] ProductImage { get; set; }

        public VatRate VatRate { get; set; }
    }
}

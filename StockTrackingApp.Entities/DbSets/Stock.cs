﻿
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StockTrackingApp.Entities.DbSets
{
    public class Stock : AuditableEntity

    {
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; } // AlışFiyat

        public virtual Warehouse Warehouse { get; set; }
        public Guid WareHouseId { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}

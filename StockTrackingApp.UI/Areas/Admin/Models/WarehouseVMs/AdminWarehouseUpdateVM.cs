﻿namespace StockTrackingApp.UI.Areas.Admin.Models.WarehouseVMs
{
    public class AdminWarehouseUpdateVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Depo Adı
        public string Location { get; set; } // Lokasyon

        public string PhoneNumber { get; set; }
    }
}

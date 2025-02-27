using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.OrderDetails
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }

        public VatRate VATRate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPriceExcludingVAT { get; set; } // KDV'siz toplam
        public decimal VATAmount { get; set; } // KDV tutarı
        public decimal TotalPriceIncludingVAT { get; set; } // KDV dahil toplam
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Customers
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } // Tedarikçi Adı

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }
    }
}

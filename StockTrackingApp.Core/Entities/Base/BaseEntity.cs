using StockTrackingApp.Core.Entities.Interfaces;
using StockTrackingApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Entities.Base
{
    public abstract class BaseEntity:ICreatableEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}

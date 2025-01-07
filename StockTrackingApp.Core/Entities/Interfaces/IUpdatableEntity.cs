using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Entities.Interfaces
{
    public interface IUpdatableEntity
    {
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}

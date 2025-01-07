using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Entities.Interfaces
{
    public interface ICreatableEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }
    }
}

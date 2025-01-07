using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.DataAccess.Interfaces
{
    public interface IAsyncRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

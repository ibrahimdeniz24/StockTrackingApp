using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IWarehouseRepository : IAsyncRepository, IAsyncFindableRepository<Warehouse>, IAsyncInsertableRepository<Warehouse>, IAsyncDeleteableRepository<Warehouse>, IAsyncQueryableRepository<Warehouse>, IAsyncUpdateableRepository<Warehouse>
    {
    }
}

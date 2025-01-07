using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface ISupplierRepository : IAsyncRepository, IAsyncInsertableRepository<Supplier>, IAsyncFindableRepository<Supplier>, IAsyncUpdateableRepository<Supplier>, IAsyncDeleteableRepository<Supplier>, IAsyncTransactionRepository
    {
    }
}

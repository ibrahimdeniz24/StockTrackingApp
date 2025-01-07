using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IStockTransactionRepository : IAsyncRepository, IAsyncFindableRepository<StockTransaction>, IAsyncInsertableRepository<StockTransaction>, IAsyncDeleteableRepository<StockTransaction>, IAsyncQueryableRepository<StockTransaction>, IAsyncUpdateableRepository<StockTransaction>,IAsyncTransactionRepository
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IProductRepository : IAsyncRepository, IAsyncFindableRepository<Product>, IAsyncInsertableRepository<Product>, IAsyncDeleteableRepository<Product>, IAsyncQueryableRepository<Product>, IAsyncUpdateableRepository<Product>
    {
    }
}

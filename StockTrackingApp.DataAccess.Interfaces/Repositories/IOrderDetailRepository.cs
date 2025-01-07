using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IAsyncRepository, IAsyncFindableRepository<OrderDetail>, IAsyncInsertableRepository<OrderDetail>, IAsyncDeleteableRepository<OrderDetail>, IAsyncQueryableRepository<OrderDetail>, IAsyncUpdateableRepository<OrderDetail>
    {
    }
}

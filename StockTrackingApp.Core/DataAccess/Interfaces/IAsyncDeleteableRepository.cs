using StockTrackingApp.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.DataAccess.Interfaces
{
    public interface IAsyncDeleteableRepository<TEntity> :IAsyncRepository where TEntity : BaseEntity
    {
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}

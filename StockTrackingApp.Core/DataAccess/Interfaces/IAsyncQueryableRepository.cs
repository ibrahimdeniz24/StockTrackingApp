using Microsoft.EntityFrameworkCore.Query;
using StockTrackingApp.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.DataAccess.Interfaces
{
    public interface IAsyncQueryableRepository<TEntity> :IAsyncRepository where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllDataAsync(bool tracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes);
    }
}

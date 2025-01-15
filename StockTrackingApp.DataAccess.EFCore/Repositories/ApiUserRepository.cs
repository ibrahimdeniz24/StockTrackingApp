

using Microsoft.EntityFrameworkCore;
using StockTrackingApp.Entities.ApiEntities;

namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class ApiUserRepository : EFBaseRepository<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(StockAppDbContext context) : base(context)
        {
        }

        public Task<ApiUser?> GetByIdentityIdAsync(string identityId)
        {
            return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
        }
    }
}

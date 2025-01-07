using Microsoft.EntityFrameworkCore;

namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class AdminRepository : EFBaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(StockAppDbContext context) : base(context)
        {
        }

        public Task<Admin?> GetByIdentityIdAsync(string identityId)
        {
            return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
        }
    }
}

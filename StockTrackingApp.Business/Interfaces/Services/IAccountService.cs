using Microsoft.AspNetCore.Identity;
using StockTrackingApp.Core.Enums;
using System.Linq.Expressions;


namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression);
        Task<IdentityUser?> FindByIdAsync(string identityId);
        Task<IdentityResult> CreateUserAsync(IdentityUser user, Roles role);
        Task<IdentityResult> DeleteUserAsync(string identityId);
        Task<Guid> GetUserIdAsync(string identityId, string role);

        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task<IdentityResult> UpdateUserAsync(IdentityUser user);
    }
}

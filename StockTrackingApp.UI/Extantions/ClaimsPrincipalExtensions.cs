using StockTrackingApp.Business.Interfaces.Services;
using System.Security.Claims;

namespace StockTrackingApp.UI.Extantions
{
    public static class ClaimsPrincipalExtensions
    {
        public static async Task<string> GetUserName(this ClaimsPrincipal user, IServiceProvider serviceProvider)
        {
            var adminService = serviceProvider.GetService<IAdminService>();

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var adminDto = await adminService.GetByIdentityIdAsync(userId);

            var adminFullName = adminDto.Data?.FirstName + " " + adminDto.Data?.LastName;

            return adminFullName;
        }
    }
}

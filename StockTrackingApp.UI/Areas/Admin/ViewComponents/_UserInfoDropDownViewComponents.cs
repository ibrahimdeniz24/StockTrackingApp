using Microsoft.AspNetCore.Identity;
using StockTrackingApp.UI.Areas.Admin.Models.AdminVMs;

namespace StockTrackingApp.UI.Areas.Admin.ViewComponents
{
    public class _UserInfoDropDownViewComponents:ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAdminService _adminService;

        public _UserInfoDropDownViewComponents(UserManager<IdentityUser> userManager, IAdminService adminService)
        {
            _userManager = userManager;
            _adminService = adminService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await _adminService.GetCurrentAdminAsync();

            var adminVm = (admin.Data).Adapt<UserInfoDropdownVM>();

            return View(adminVm); // "Default" view'ine admin adını gönderiyoruz.
        }
    }
}

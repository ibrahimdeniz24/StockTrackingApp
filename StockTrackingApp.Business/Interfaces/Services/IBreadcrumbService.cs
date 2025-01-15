
using StockTrackingApp.Dtos.BreadcrumbItem;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IBreadcrumbService
    {
        List<BreadcrumbItemDto> GenerateBreadcrumbs(string area, string controller, string action, bool isHomePage, bool isLoginPage);
        string GetDisplayName(string controllerName, string actionName);
    }
}

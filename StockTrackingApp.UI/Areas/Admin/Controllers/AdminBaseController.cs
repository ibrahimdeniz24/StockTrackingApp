using Microsoft.AspNetCore.Authorization;
using StockTrackingApp.UI.Controllers;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : BaseController
    {

    }
}

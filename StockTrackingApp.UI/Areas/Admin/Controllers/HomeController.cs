using Microsoft.AspNetCore.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerService;
        private readonly IStockService _stockservice;

        public HomeController(ISupplierService supplierService, ICustomerService customerService, IStockService stockservice)
        {
            _supplierService = supplierService;
            _customerService = customerService;
            _stockservice = stockservice;
        }

        public async Task<IActionResult> Index()
        {
            var supplilerList =  await _supplierService.GetAllAsync();

            var customerList = await _customerService.GetAllAsync();

            var stockList = await _stockservice.GetAllAsync();
            
            
            // Toplam değeri hesapla
            decimal totalStockValue = stockList.Data.Sum(stock => stock.Quantity * stock.PurchasePrice);
            // ViewBag'e ata
            ViewBag.TotalStockValue = totalStockValue;
            ViewBag.SupplierCount = supplilerList.Data.Count;
            ViewBag.CustomerCount = customerList.Data.Count;
            ViewBag.StockCount = stockList.Data.Count;


            return View();
        }
    }
}

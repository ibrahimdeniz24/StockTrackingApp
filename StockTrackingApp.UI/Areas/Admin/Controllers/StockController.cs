using AutoMapper;
using StockTrackingApp.Dtos.Stocks;
using StockTrackingApp.UI.Areas.Admin.Models.StockVMs;
using System.Text;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class StockController : AdminBaseController
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;

        public StockController(IStockService stockService, IProductService productService, IWarehouseService warehouseService, IMapper mapper, ISupplierService supplierService)
        {
            _stockService = stockService;
            _productService = productService;
            _warehouseService = warehouseService;
            _mapper = mapper;
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            var stocksGetResult = await _stockService.GetAllAsync();
            var stockList = _mapper.Map<List<AdminStockListVM>>(stocksGetResult.Data).OrderBy(o => o.ProductName).ToList();


            var pagedList = stockList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            return View(pagedList);
        }

        public async Task<List<AdminStockListVM>> Search(string product)
        {
            var productsGetResult = await _productService.GetAllAsync();
            var productList = _mapper.Map<List<AdminStockListVM>>(productsGetResult.Data);

            var searchList = productList
                .Where(s => s.ProductName.IndexOf(product, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.ProductName)
                .ToList();

            return searchList;
        }


        [HttpPost]
        public async Task<IActionResult> Create(AdminStockCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                var errorMessages = new StringBuilder();

                foreach (var error in errors)
                {
                    if (errorMessages.Length > 0)
                    {
                        errorMessages.Append(", ");

                        if (errorMessages.ToString().Contains(error.ErrorMessage))
                        {
                            continue;
                        }
                    }

                    errorMessages.Append(error.ErrorMessage);
                }

                NotifyError(errorMessages.ToString());
                return RedirectToAction(nameof(Index));
            }

            var stockDto = _mapper.Map<StockCreateDto>(model);
            var addResult = await _stockService.AddAsync(stockDto);

            if (!addResult.IsSuccess)
            {
                NotifyErrorLocalized(addResult.Message);
                return RedirectToAction(nameof(Index));
            }

            NotifySuccessLocalized(addResult.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var getStockResult = await _stockService.GetDetailsByIdAsync(id);
            if (!getStockResult.IsSuccess)
            {
                NotifyErrorLocalized(getStockResult.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AdminStockDetailsVM>(getStockResult.Data));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _stockService.DeleteAsync(id);
            if (!deleteResult.IsSuccess)
            {
                NotifyErrorLocalized(deleteResult.Message);
                return RedirectToAction(nameof(Index));
            }
            NotifySuccessLocalized(deleteResult.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminStockUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                var errorMessages = new StringBuilder();
                foreach (var error in errors)
                {
                    if (errorMessages.Length > 0)
                    {
                        errorMessages.Append(", ");
                        if (errorMessages.ToString().Contains(error.ErrorMessage))
                        {
                            continue;
                        }
                    }
                    errorMessages.Append(error.ErrorMessage);
                }
                NotifyError(errorMessages.ToString());
                return RedirectToAction(nameof(Index));
            }
            var stockDto = _mapper.Map<StockUpdateDto>(model);
            var updateResult = await _stockService.UpdateAsync(stockDto);
            if (!updateResult.IsSuccess)
            {
                NotifyErrorLocalized(updateResult.Message);
                return RedirectToAction(nameof(Index));
            }
            NotifySuccessLocalized(updateResult.Message);
            return RedirectToAction(nameof(Index));
        }

        //Ajax Methods 
        public async Task<IActionResult> GetWarehouses()
        {
            var warehousesGetResult = await _warehouseService.GetAllAsync();
            var warehouseList = warehousesGetResult.Data.Select(s => new { s.Id, s.Name }).ToList();
            return Json(warehouseList);
        }

        public async Task<IActionResult> GetProducts(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }

            var products = await _productService.GetAllAsync(); // Tüm müşterileri getir
            var filteredProducts = products.Data
                .Where(c => c.
                Name.Contains(term, StringComparison.OrdinalIgnoreCase)) // İçerenleri filtrele
                .Select(c => new { id = c.Id, text = c.Name }) // JSON formatına çevir
                .ToList();

            return Json(filteredProducts);
        }

        //Ajax ile modala veri doldurmak için
        [HttpGet]
        public async Task<IActionResult> GetSuppliers(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }

            var suppliers = await _supplierService.GetAllAsync();

            // Eğer gelen data DTO içeriyorsa, doğru şekilde isimlendir
            var supplierList = suppliers.Data.
                Where(c => c.CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase)).
                Select(c => new { id = c.Id, text = c.CompanyName }).ToList();
            return Json(supplierList);
        }


        public async Task<JsonResult> GetProductById(Guid id)
        {
            var stock = await _stockService.GetByIdAsync(id); // Asenkron olarak ürünü al
            if (stock != null)
            {
                return Json(new { id = stock.Data.Id, text = stock.Data.ProductName }); // ID ve isim döndür
            }
            return Json(null);
        }

    }
}

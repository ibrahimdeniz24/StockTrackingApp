using AutoMapper;
using Microsoft.Build.Framework;
using StockTrackingApp.Dtos.PurchaseOrders;
using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.PurchaseOrderVMs;
using System.Text;
using X.PagedList;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class PurchaseOrderController : AdminBaseController
    {

        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IPurchaseOrderDetailService _purchaseOrderDetailService;
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        private readonly IStockService _stockService;

        public PurchaseOrderController(IStockService stockService, ISupplierService supplierService, IMapper mapper, IPurchaseOrderDetailService purchaseOrderDetailService, IPurchaseOrderService purchaseOrderService)
        {
            _stockService = stockService;
            _supplierService = supplierService;
            _mapper = mapper;
            _purchaseOrderDetailService = purchaseOrderDetailService;
            _purchaseOrderService = purchaseOrderService;
        }


        public async Task<IActionResult> Index(int? page, int pageSize = 10, string searchTerm = null)
        {
            int pageNumber = page ?? 1;
            // Veritabanı seviyesinde sayfalama
            var purchaseOrderPagedResult = await _purchaseOrderService.GetPagedPurchaseOrdersAsync(pageNumber, pageSize, searchTerm);
            // Veritabanı sonuçlarını VM'ye dönüştürme
            var purchaseOrderList = _mapper.Map<List<AdminPurchaseOrderListVM>>(purchaseOrderPagedResult.Items);
            // StaticPagedList ile sayfalama yapma
            var pagedList = new StaticPagedList<AdminPurchaseOrderListVM>(
                purchaseOrderList, pageNumber, pageSize, purchaseOrderPagedResult.TotalCount);
            // Sayfa boyutunu ViewBag'e gönderme
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;
            // Enum değerlerini View'e gönderme (VAT oranları)
            var vatRates = Enum.GetValues(typeof(VatRate))
                .Cast<VatRate>()
                .Select(v => new { Id = (int)v, Name = v.GetDisplayName() })
                .ToList();
            ViewBag.VatRates = vatRates;
            return View(pagedList);
        }



        public async Task<IActionResult> Create(AdminPurchaseOrderCreateVM model)
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
            var purchaseOrderCreateDto = _mapper.Map<PurchaseOrderCreateDto>(model);
            var addResult = await _purchaseOrderService.AddAsync(purchaseOrderCreateDto);
            if (addResult.IsSuccess)
            {
                NotifyErrorLocalized(addResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(addResult.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Update(AdminPurchaseOrderUpdateVM model)
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


            var purchaseOrderUpdateDto = _mapper.Map<PurchaseOrderUpdateDto>(model);
            var updateResult = await _purchaseOrderService.UpdateAsync(purchaseOrderUpdateDto);

            if (updateResult.IsSuccess)
            {
                NotifyErrorLocalized(updateResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(updateResult.Message);
                return RedirectToAction(nameof(Index));
            }




        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _purchaseOrderService.DeleteAsync(id);
            if (deleteResult.IsSuccess)
            {
                NotifyErrorLocalized(deleteResult.Message);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(deleteResult.Message);
                return RedirectToAction(nameof(Index));

            }
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var purchaseOrderDetailsDto = await _purchaseOrderService.GetDetailsByIdAsync(id);

            if (!purchaseOrderDetailsDto.IsSuccess)
            {
                NotifyErrorLocalized(purchaseOrderDetailsDto.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AdminPurchaseOrderDetailsVM>(purchaseOrderDetailsDto.Data));
        }



        [HttpGet]
        public async Task<IActionResult> GetStocks(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }

            var stocks = await _stockService.GetAllAsync(); // Tüm Stokları getir
            var filteredStocks = stocks.Data
                .Where(c => c.
                ProductName.Contains(term, StringComparison.OrdinalIgnoreCase)) // İçerenleri filtrele
                .Select(c => new { id = c.Id, text = c.ProductName }) // JSON formatına çevir
                .ToList();

            return Json(filteredStocks);
        }

        [HttpGet]

        public async Task<IActionResult> GetSuppliers(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }
            var suppliers = await _supplierService.GetAllAsync(); // Tüm Tedarikçileri getir
            var filteredSuppliers = suppliers.Data
                .Where(c => c.CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase)) // İçerenleri filtrele
                .Select(c => new { id = c.Id, text = c.CompanyName }) // JSON formatına çevir
                .ToList();
            return Json(filteredSuppliers);



        }
    }
}


using AutoMapper;
using StockTrackingApp.Business.Constants;
using StockTrackingApp.Core.Utilities.Results.Concrete;
using StockTrackingApp.Dtos.Suppliers;
using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs;
using System.Text;
using X.PagedList;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class SupplierController : AdminBaseController
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 10, string searchTerm = null)
        {
            int pageNumber = page ?? 1;
            var suppliersGetResult = await _supplierService.GetPagedOrdersAsync(pageNumber,pageSize,searchTerm);


            var supplierList = _mapper.Map<List<AdminSupplierListVM>>(suppliersGetResult.Items);

            var pagedList = new StaticPagedList<AdminSupplierListVM>(supplierList, pageNumber, pageSize, suppliersGetResult.TotalCount);

            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;


            var vatRates = Enum.GetValues(typeof(VatRate))
                .Cast<VatRate>()
                .Select(v => new { Id = (int)v, Name = v.GetDisplayName() })
                .ToList();

            ViewBag.PageSize = pageSize;

            return View(pagedList);
        }


        public async Task<List<AdminSupplierListVM>> Search(string supplier)
        {
            var suppliersGetResult = await _supplierService.GetAllAsync();
            var supplierList = _mapper.Map<List<AdminSupplierListVM>>(suppliersGetResult.Data);

            var searchList = supplierList
                .Where(s => s.CompanyName.IndexOf(supplier, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.CompanyName)
                .ToList();

            return searchList;
        }


        [HttpPost]
        public async Task<IActionResult> Create(AdminSupplierCreateVM model)
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
            if (model == null)
            {
                NotifyErrorLocalized(Messages.ModelisNull);
                return RedirectToAction(nameof(Index));
            }

            var supplierDto = _mapper.Map<SupplierCreateDto>(model);

            var addResult = await _supplierService.AddAsync(supplierDto);
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
            var getSupplier = await _supplierService.GetDetailsByIdAsync(id);

            if (!getSupplier.IsSuccess)
            {
                NotifyErrorLocalized(getSupplier.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AdminSupplierDetailsVM>(getSupplier.Data));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _supplierService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                NotifySuccessLocalized(result.Message);
            }
            else
            {
                NotifyErrorLocalized(result.Message);
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminSupplierUpdateVM supplierUpdateVM)
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

            var supplierUpdateDto = _mapper.Map<SupplierUpdateDto>(supplierUpdateVM);
            var supplierUpdateResponse = await _supplierService.UpdateAsync(supplierUpdateDto);
            if (!supplierUpdateResponse.IsSuccess)
            {
                NotifyErrorLocalized(supplierUpdateResponse.Message);
                return View(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(supplierUpdateResponse.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsSelectList()
        {
            var suppliers = await _supplierService.GetAllSupplierAsSelectListAsync();
            return Json(suppliers);
        }


    }


}

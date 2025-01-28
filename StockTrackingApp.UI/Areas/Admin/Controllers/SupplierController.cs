using AutoMapper;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Suppliers;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs;
using System.Text;
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
        public async Task<IActionResult> Index(int? page, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            var categoriesGetResult = await _supplierService.GetAllAsync();
            var categoryList = _mapper.Map<List<AdminSupplierListVM>>(categoriesGetResult.Data).OrderBy(o => o.CompanyName).ToList();


            var pagedList = categoryList.ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            return View(pagedList);
        }


        public async Task<List<AdminSupplierListVM>> Search(string supplier)
        {
            var categoriesGetResult = await _supplierService.GetAllAsync();
            var categoryList = _mapper.Map<List<AdminSupplierListVM>>(categoriesGetResult.Data);

            var searchList = categoryList
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

            var categoryDto = _mapper.Map<SupplierCreateDto>(model);

            var addResult = await _supplierService.AddAsync(categoryDto);
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
            var getCategory = await _supplierService.GetDetailsByIdAsync(id);

            if (!getCategory.IsSuccess)
            {
                NotifyErrorLocalized(getCategory.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AdminCategoryDetailsVM>(getCategory.Data));
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

            var categoryUpdateDto = _mapper.Map<SupplierUpdateDto>(supplierUpdateVM);
            var categoryUpdateResponse = await _supplierService.UpdateAsync(categoryUpdateDto);
            if (!categoryUpdateResponse.IsSuccess)
            {
                NotifyErrorLocalized(categoryUpdateResponse.Message);
                return View(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(categoryUpdateResponse.Message);
            }

            return RedirectToAction(nameof(Index));
        }



    }
}

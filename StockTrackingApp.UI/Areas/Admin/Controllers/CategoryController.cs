using AutoMapper;
using StockTrackingApp.Business.Constants;
using StockTrackingApp.Core.Utilities.Results.Concrete;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using System.Text;
using X.PagedList;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 10, string searchTerm = null)
        {
            int pageNumber = page ?? 1;

            var categoryPagedResult = await _categoryService.GetPagedOrdersAsync(pageNumber, pageSize, searchTerm);

            var categoryList = _mapper.Map<List<AdminCategoryListVM>>(categoryPagedResult.Items);

            var pagedList = new StaticPagedList<AdminCategoryListVM>(categoryList, pageNumber, pageSize, categoryPagedResult.TotalCount);

            // Sayfa boyutunu ViewBag'e gönderme
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            var vatRates = Enum.GetValues(typeof(VatRate))
                .Cast<VatRate>()
                .Select(v => new { Id = (int)v, Name = v.GetDisplayName() }).ToList();

            ViewBag.VatRates = vatRates;

            return View(pagedList);

        }


        public async Task<List<AdminCategoryListVM>> Search(string category)
        {
            var categoriesGetResult = await _categoryService.GetAllAsync();
            var categoryList = _mapper.Map<List<AdminCategoryListVM>>(categoriesGetResult.Data);

            var searchList = categoryList
                .Where(s => s.CategoryName.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.CategoryName)
                .ToList();

            return searchList;
        }



        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryCreateVM model)
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

            var categoryDto = _mapper.Map<CategoryCreateDto>(model);

            var addResult = await _categoryService.AddAsync(categoryDto);
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
            var getCategory = await _categoryService.GetDetailsByIdAsync(id);

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
            var result = await _categoryService.DeleteAsync(id);
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
        public async Task<IActionResult> Update(AdminCategoryUpdateVM categoryUpdateVM)
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

            var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(categoryUpdateVM);
            var categoryUpdateResponse = await _categoryService.UpdateAsync(categoryUpdateDto);
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


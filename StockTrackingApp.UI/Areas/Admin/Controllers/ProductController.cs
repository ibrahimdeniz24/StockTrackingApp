using AutoMapper;
using MailKit.Search;
using Microsoft.AspNetCore.Http.Metadata;
using StockTrackingApp.Core.Utilities.Helpers;
using StockTrackingApp.Dtos.Products;
using StockTrackingApp.Entities.Enums;
using StockTrackingApp.UI.Areas.Admin.Models.ProductVMs;
using StockTrackingApp.UI.Extantions;
using System.Text;
using X.PagedList;
using X.PagedList.Extensions;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _supplierService = supplierService;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, int pageSize = 5, string searchTerm = null)
        {
            // Sayfa numarası kontrolüz
            int pageNumber = page ?? 1;

            var productPagedResult = await _productService.GetPagedOrdersAsync(pageNumber, pageSize, searchTerm);

            var productList = _mapper.Map<List<AdminProductListVM>>(productPagedResult.Items);


            var pagedList = new StaticPagedList<AdminProductListVM>(productList, pageNumber, pageSize, productPagedResult.TotalCount);

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



        public async Task<List<AdminProductListVM>> Search(string product)
        {
            var productsGetResult = await _productService.GetAllAsync();
            var productList = _mapper.Map<List<AdminProductListVM>>(productsGetResult.Data);

            var searchList = productList
                .Where(s => s.Name.IndexOf(product, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(o => o.Name)
                .ToList();

            return searchList;
        }


        [HttpPost]
        public async Task<IActionResult> Create(AdminProductCreateVM model)
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

            var productDto = _mapper.Map<ProductCreateDto>(model);

            if (model.NewPicture == null || model.NewPicture.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            productDto.ProductImage = await model.NewPicture.FileToByteArrayAsync();
            var addResult = await _productService.AddAsync(productDto);

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
            var getProduct = await _productService.GetDetailsByIdAsync(id);

            if (!getProduct.IsSuccess)
            {
                NotifyErrorLocalized(getProduct.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AdminProductDetailsVM>(getProduct.Data));
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productService.DeleteAsync(id);
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

        public async Task<IActionResult> Update(AdminProductUpdateVM updateVM)
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


            var productUpdateDto = _mapper.Map<ProductUpdateDto>(updateVM);
            if (updateVM.NewPicture == null || updateVM.NewPicture.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            productUpdateDto.ProductImage = await updateVM.NewPicture.FileToByteArrayAsync();


            var productUpdateResult = await _productService.UpdateAsync(productUpdateDto);

            if (!productUpdateResult.IsSuccess)
            {
                NotifyErrorLocalized(productUpdateResult.Message);
                return View(nameof(Index));
            }
            else
            {
                NotifySuccessLocalized(productUpdateResult.Message);
            }

            return RedirectToAction(nameof(Index));

        }




        //Ajax ile modala veri doldurmak için
        [HttpGet]
        public async Task<IActionResult> GetCategories(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new List<object>());
            }
            var categories = await _categoryService.GetAllAsync();

            // Eğer gelen data DTO içeriyorsa, doğru şekilde isimlendir
            var filteredCategoryList = categories.Data.
                Where(c => c.CategoryName.Contains(term, StringComparison.OrdinalIgnoreCase)).
                Select(c => new { id = c.Id, text = c.CategoryName }).ToList();
            return Json(filteredCategoryList);
        }

    }
}

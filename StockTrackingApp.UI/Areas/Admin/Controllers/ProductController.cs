using AutoMapper;
using StockTrackingApp.Dtos.Products;
using StockTrackingApp.UI.Areas.Admin.Models.ProductVMs;
using StockTrackingApp.UI.Extantions;
using System.Text;
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
        public async Task<IActionResult> Index(int? page, int pageSize = 10)
        {
            // Sayfa numarası kontrolüz
            page ??= 1;
            if (pageSize <= 0) pageSize = 10; // Geçersiz pageSize değerlerini engelle

            // Ürünleri getir ve AdminProductListVM'e map et
            var productsGetResult = await _productService.GetAllAsync();
            var productList = _mapper.Map<List<AdminProductListVM>>(productsGetResult.Data)
                                     .OrderBy(o => o.Name) // Sıralama önce yapılmalı
                                     .ToList();

            // Sayfalama işlemi
            var pagedList = productList.ToPagedList(page.Value, pageSize);

            // View'a gerekli verileri gönder
            ViewBag.PageSize = pageSize;

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

            if (model.NewPicture == null || model.NewPicture.Length==0)
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

    }
}

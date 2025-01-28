using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace StockTrackingApp.UI.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IProductSupplierService _productSupplierService;

        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, ISupplierService supplierService, IProductSupplierService productSupplierService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _productSupplierService = productSupplierService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
